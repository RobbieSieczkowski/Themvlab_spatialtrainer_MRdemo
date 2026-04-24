using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSequence : MonoBehaviour
{
    static private List<GameObject> dimensionalScaleRightHand;
    static private List<GameObject> dimensionalScaleLeftHand;
    static private List<AudioClip> dimensionalScaleChords;

    static private List<GameObject> diagonalScaleRightHand;
    static private List<GameObject> diagonalScaleLeftHand;
    static private List<AudioClip> diagonalScaleChords;

    static private List<GameObject> axisScaleRightHand;
    static private List<GameObject> axisScaleLeftHand;
    static private List<AudioClip> axisScaleChords;

    static private List<GameObject> girdleScaleRightHand;
    static private List<GameObject> girdleScaleLeftHand;
    static private List<AudioClip> girdleScaleChords;

    static private List<GameObject> currentScale;

    private GameObject currentBeat;

    public GameObject backward;
    public GameObject deep;
    public GameObject deepBackward;
    public GameObject deepForward;
    public GameObject deepLeft;
    public GameObject deepLeftBackward;
    public GameObject deepLeftForward;
    public GameObject deepRight;
    public GameObject deepRightBackward;
    public GameObject deepRightForward;
    public GameObject forward;
    public GameObject high;
    public GameObject highBackward;
    public GameObject highForward;
    public GameObject highLeft;
    public GameObject highLeftBackward;
    public GameObject highLeftForward;
    public GameObject highRight;
    public GameObject highRightBackward;
    public GameObject highRightForward;
    public GameObject left;
    public GameObject leftBackward;
    public GameObject leftForward;
    public GameObject right;
    public GameObject rightBackward;
    public GameObject rightForward;

    private int count;
    private bool rightHandScaleActive;
    private bool leftHandScaleActive;

    // NEW: remember which scale the user picked so L/R toggle can re-apply it
    private int currentScaleIndex = 0;

    [SerializeField] private AudioClip a;
    [SerializeField] private AudioClip b;
    [SerializeField] private AudioClip c;
    [SerializeField] private AudioClip d;
    [SerializeField] private AudioClip e;
    [SerializeField] private AudioClip f;
    [SerializeField] private AudioClip g;

    public bool isTutorial;

    [Header("Platonic Solids")]
    [SerializeField] public GameObject cube;
    [SerializeField] public GameObject octahedron;
    [SerializeField] public GameObject icosahedron;

    void Start()
    {
        SetScaleSequences();

        rightHandScaleActive = true;  // default: Right
        leftHandScaleActive = false;

        currentScaleIndex = 0;
        RefreshCurrentScale();

        count = 0;
        currentBeat = currentScale[0];
        currentBeat.transform.GetChild(0).gameObject.SetActive(true);

        isTutorial = false;
    }

    void Update()
    {
        if (rightHandScaleActive && (currentBeat.GetComponent<TouchMe>().CollisionDetector() == "Right"))
        {
            ScaleProgressor();
        }
        else if (leftHandScaleActive && currentBeat.GetComponent<TouchMe>().CollisionDetector() == "Left")
        {
            ScaleProgressor();
        }
    }

    public void LeftOrRight(bool rOrL)
    {
        if (rOrL)
        {
            rightHandScaleActive = true;
            leftHandScaleActive = false;
        }
        else
        {
            rightHandScaleActive = false;
            leftHandScaleActive = true;
        }

        // Actually swap the active scale to the L/R counterpart
        RefreshCurrentScale();
        ResetState();
    }

    void SetScaleSequences()
    {
        // Dimensional
        dimensionalScaleRightHand = new List<GameObject>() { high, deep, right, left, forward, backward };
        dimensionalScaleLeftHand = new List<GameObject>() { high, deep, left, right, forward, backward };
        dimensionalScaleChords = new List<AudioClip>() { c, d, e, f, g, a };

        // Diagonal
        diagonalScaleRightHand = new List<GameObject>() { highRightForward, deepLeftBackward, highLeftForward, deepRightBackward, highLeftBackward, deepRightForward, highRightBackward, deepLeftForward };
        diagonalScaleLeftHand = new List<GameObject>() { highLeftForward, deepRightBackward, highRightForward, deepLeftBackward, highRightBackward, deepLeftForward, highLeftBackward, deepRightForward };
        diagonalScaleChords = new List<AudioClip>() { a, b, c, d, e, f, g, a };

        // Axis
        axisScaleRightHand = new List<GameObject>() { highRight, deepBackward, rightForward, deepLeft, highForward, leftBackward };
        axisScaleLeftHand = new List<GameObject>() { highLeft, deepBackward, leftForward, deepRight, highForward, rightBackward };
        axisScaleChords = new List<AudioClip>() { e, f, g, a, c, d };

        // Girdle
        girdleScaleRightHand = new List<GameObject>() { rightBackward, deepRight, deepForward, leftForward, highLeft, highBackward };
        girdleScaleLeftHand = new List<GameObject>() { leftBackward, deepLeft, deepForward, rightForward, highRight, highBackward };
        girdleScaleChords = new List<AudioClip>() { g, a, b, c, d, e };
    }

    public void SelectScale(int index)
    {
        currentScaleIndex = index;
        RefreshCurrentScale();
        ResetState();
    }

    // NEW: centralizes the scale selection so both SelectScale and LeftOrRight use it
    private void RefreshCurrentScale()
    {
        switch (currentScaleIndex)
        {
            case 0:
                currentScale = rightHandScaleActive ? dimensionalScaleRightHand : dimensionalScaleLeftHand;
                break;
            case 1:
                currentScale = rightHandScaleActive ? diagonalScaleRightHand : diagonalScaleLeftHand;
                break;
            case 2:
                currentScale = rightHandScaleActive ? axisScaleRightHand : axisScaleLeftHand;
                break;
            case 3:
                currentScale = rightHandScaleActive ? girdleScaleRightHand : girdleScaleLeftHand;
                break;
        }

        UpdatePlatonicSolid();
    }

    void ScaleProgressor()
    {
        Debug.Log("SCALE PROGRESSION");

        // Figure out which hand triggered this progression so we only rumble that controller
        string hitHand = rightHandScaleActive ? "Right" : "Left";

        currentBeat.transform.GetChild(0).gameObject.SetActive(false);

        if (count < currentScale.Count - 1)
        {
            SoundManager.instance.PlaySoundClip(GetActiveChords()[count], currentBeat.transform, 0.5f);
            FireHaptic(hitHand);

            count = count + 1;
            currentBeat = currentScale[count];
            currentBeat.transform.GetChild(0).gameObject.SetActive(true);

            // NEW: clear any stale collision data on the new beat
            currentBeat.GetComponent<TouchMe>().ClearState();
        }
        else
        {
            Debug.Log("REPEAT");

            // Play the final chord before looping back
            SoundManager.instance.PlaySoundClip(GetActiveChords()[count], currentBeat.transform, 0.5f);
            FireHaptic(hitHand);

            currentBeat = currentScale[0];
            currentBeat.transform.GetChild(0).gameObject.SetActive(true);
            count = 0;
            
            // NEW: clear any stale collision data on the new beat
            currentBeat.GetComponent<TouchMe>().ClearState();
        }
    }

    private List<AudioClip> GetActiveChords()
    {
        switch (currentScaleIndex)
        {
            case 0: return dimensionalScaleChords;
            case 1: return diagonalScaleChords;
            case 2: return axisScaleChords;
            case 3: return girdleScaleChords;
            default: return dimensionalScaleChords;
        }
    }

    private void FireHaptic(string hand)
    {
        if (HapticFX.instance == null) return;

        if (hand == "Right") HapticFX.instance.PulseRight();
        else if (hand == "Left") HapticFX.instance.PulseLeft();
    }

    private void UpdatePlatonicSolid()
    {
        if (isTutorial) return;

        // Deactivate all, then activate the current one
        if (octahedron != null) octahedron.SetActive(currentScaleIndex == 0);
        if (cube != null) cube.SetActive(currentScaleIndex == 1);
        if (icosahedron != null) icosahedron.SetActive(currentScaleIndex == 2 || currentScaleIndex == 3);

    }

    public void ResetState()
    {
        count = 0;

        if (currentScale != null && currentScale.Count > 0)
        {
            // deactivate whatever was highlighted, then highlight beat 0 of the new scale
            if (currentBeat != null)
            {
                currentBeat.transform.GetChild(0).gameObject.SetActive(false);
            }
            currentBeat = currentScale[0];
            currentBeat.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}