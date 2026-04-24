using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Drives the Laban Scales Tutorial. Plays the main VO audio and fires scripted
/// events at specific timestamps (spawn pulls, light up specific pulls, hand off
/// to Free-Practice-style interaction at the scale-sequence moment, start a
/// looping end-line).
///
/// Designed to be called from NextScene when Tutorial mode is activated.
/// Call StopTutorial() to cleanly abort if the user returns to the main menu.
/// </summary>
public class TutorialController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ScaleSequence scaleSequence;
    [SerializeField] private AudioSource voAudioSource;

    [Header("Audio Clips")]
    [Tooltip("Main tutorial voiceover, start to 2:22.")]
    [SerializeField] private AudioClip mainVoiceover;

    [Tooltip("End-line audio that loops every 15 seconds until user returns to menu.")]
    [SerializeField] private AudioClip endingLoopClip;

    [Tooltip("Seconds between loops of the ending line. Script says 15.")]
    [SerializeField] private float endingLoopInterval = 15f;

    [Header("Timestamped Events")]
    [Tooltip("Events fire when VO playback passes their time. Times are in seconds from VO start.")]
    [SerializeField] private List<TimedEvent> timedEvents = new List<TimedEvent>();

    [Header("Debug")]
    [SerializeField] private bool logEvents = false;

    private Coroutine tutorialRoutine;
    private Coroutine endingLoopRoutine;

    [System.Serializable]
    public class TimedEvent
    {
        [Tooltip("Seconds from VO start when this event fires.")]
        public float time;

        [Tooltip("Human-readable label for Inspector readability only.")]
        public string label;

        [Tooltip("Actions to run when this event fires. Wire UnityEvents in the Inspector.")]
        public UnityEvent onFire;
    }

    /// <summary>Begin the tutorial. Called from NextScene when Tutorial mode activates.</summary>
    public void StartTutorial()
    {
        Debug.Log("[Tutorial] StartTutorial called");

        StopTutorial();  // safety: don't stack coroutines if called twice

        TurnOffAllDimensionalHighlights();

        tutorialRoutine = StartCoroutine(RunTutorial());
    }

    /// <summary>Abort tutorial cleanly (stops audio, stops event firing, stops looping end line).</summary>
    public void StopTutorial()
    {
        if (tutorialRoutine != null)
        {
            StopCoroutine(tutorialRoutine);
            tutorialRoutine = null;
        }
        if (endingLoopRoutine != null)
        {
            StopCoroutine(endingLoopRoutine);
            endingLoopRoutine = null;
        }
        if (voAudioSource != null && voAudioSource.isPlaying)
        {
            voAudioSource.Stop();
        }
    }

    private IEnumerator RunTutorial()
    {
        if (mainVoiceover == null || voAudioSource == null)
        {
            Debug.LogWarning("[Tutorial] Missing VO clip or AudioSource. Aborting.", this);
            yield break;
        }

        // Play VO
        voAudioSource.clip = mainVoiceover;
        voAudioSource.loop = false;
        voAudioSource.Play();

        // Sort events by time so they fire in order regardless of Inspector ordering
        List<TimedEvent> sorted = new List<TimedEvent>(timedEvents);
        sorted.Sort((a, b) => a.time.CompareTo(b.time));

        int nextIndex = 0;
        float startTime = Time.time;

        // Fire events as VO playback crosses each timestamp
        while (nextIndex < sorted.Count)
        {
            float elapsed = Time.time - startTime;
            if (elapsed >= sorted[nextIndex].time)
            {
                if (logEvents)
                {
                    Debug.Log($"[Tutorial] t={elapsed:F2} firing '{sorted[nextIndex].label}'");
                }
                sorted[nextIndex].onFire?.Invoke();
                nextIndex++;
            }
            yield return null;
        }

        // After all events have fired, the main VO will continue playing on its own
        // until it ends. Nothing more to do here -- the ending-loop event should
        // have been scheduled as one of the timed events.
        tutorialRoutine = null;
    }

    // -------------------------------------------------------------------------
    // Convenience methods to wire into UnityEvents in the Inspector.
    // -------------------------------------------------------------------------

    /// <summary>Light up a single beat's highlight (child[0]) and turn off all others in the dimensional scale.</summary>
    public void HighlightPullOnly(GameObject beat)
    {
        if (beat == null) return;

        // Turn off all the dimensional pulls' highlights first
        TurnOffAllDimensionalHighlights();

        // Then turn on just the requested one
        if (beat.transform.childCount > 0)
        {
            beat.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    /// <summary>Turn off highlights on all six dimensional beats.</summary>
    public void TurnOffAllDimensionalHighlights()
    {
        if (scaleSequence == null) return;

        TryHighlight(scaleSequence.high, false);
        TryHighlight(scaleSequence.deep, false);
        TryHighlight(scaleSequence.left, false);
        TryHighlight(scaleSequence.right, false);
        TryHighlight(scaleSequence.forward, false);
        TryHighlight(scaleSequence.backward, false);
    }

    private void TryHighlight(GameObject beat, bool on)
    {
        if (beat == null) return;
        if (beat.transform.childCount == 0) return;
        beat.transform.GetChild(0).gameObject.SetActive(on);
    }

    /// <summary>
    /// Hand off to free-practice-like interaction: user can now progress the scale
    /// by physically hitting beats. Called at the 1:55 mark.
    /// </summary>
    public void HandOffToSequencePlay()
    {
        if (scaleSequence == null) return;

        TurnOffAllDimensionalHighlights();

        scaleSequence.enabled = true;
        scaleSequence.isTutorial = false;   // collisions now drive progression, not VO
        ClearAllBeatTouchStates();

        // Reset to beat 0 of the dimensional scale (assumes currentScaleIndex = 0 was already set)
        scaleSequence.SelectScale(0);
    }

    private void ClearAllBeatTouchStates()
    {
        TryClear(scaleSequence.high);
        TryClear(scaleSequence.deep);
        TryClear(scaleSequence.left);
        TryClear(scaleSequence.right);
        TryClear(scaleSequence.forward);
        TryClear(scaleSequence.backward);
    }

    private void TryClear(GameObject beat)
    {
        if (beat == null) return;
        TouchMe tm = beat.GetComponent<TouchMe>();
        if (tm != null) tm.ClearState();
    }

    /// <summary>Start the looping ending-line audio. Called at the 2:22 mark.</summary>
    public void StartEndingLoop()
    {
        if (endingLoopRoutine != null)
        {
            StopCoroutine(endingLoopRoutine);
        }
        endingLoopRoutine = StartCoroutine(EndingLoopRoutine());
    }

    private IEnumerator EndingLoopRoutine()
    {
        if (endingLoopClip == null || voAudioSource == null) yield break;

        while (true)
        {
            voAudioSource.clip = endingLoopClip;
            voAudioSource.loop = false;
            voAudioSource.Play();
            yield return new WaitForSeconds(endingLoopClip.length);
            yield return new WaitForSeconds(endingLoopInterval);
        }
    }
}