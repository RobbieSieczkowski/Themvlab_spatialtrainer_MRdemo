using System.Collections;
using UnityEngine;

/// <summary>
/// Singleton that provides short haptic rumble pulses to the left or right controller
/// via the Meta OVRInput API. Call <see cref="PulseRight"/> / <see cref="PulseLeft"/>
/// from any script to fire a tactile confirmation.
/// </summary>
public class HapticFX : MonoBehaviour
{
    public static HapticFX instance;

    [Header("Default Pulse")]
    [Tooltip("Length of the rumble pulse in seconds. Short (50-100ms) feels like a confirmation tap.")]
    [SerializeField] private float defaultDuration = 0.08f;

    [Tooltip("Vibration amplitude, 0 (none) to 1 (max). 0.5-0.8 is a comfortable hit; max is startling.")]
    [Range(0f, 1f)]
    [SerializeField] private float defaultAmplitude = 0.6f;

    [Tooltip("Vibration frequency, 0 (low buzz) to 1 (high buzz). 0.5 is a neutral thump.")]
    [Range(0f, 1f)]
    [SerializeField] private float defaultFrequency = 0.5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>Pulse the right controller with default settings.</summary>
    public void PulseRight()
    {
        StartCoroutine(PulseCoroutine(OVRInput.Controller.RTouch, defaultDuration, defaultAmplitude, defaultFrequency));
    }

    /// <summary>Pulse the left controller with default settings.</summary>
    public void PulseLeft()
    {
        StartCoroutine(PulseCoroutine(OVRInput.Controller.LTouch, defaultDuration, defaultAmplitude, defaultFrequency));
    }

    /// <summary>Pulse a specific controller with custom timing/intensity.</summary>
    public void Pulse(OVRInput.Controller controller, float duration, float amplitude, float frequency)
    {
        StartCoroutine(PulseCoroutine(controller, duration, amplitude, frequency));
    }

    private IEnumerator PulseCoroutine(OVRInput.Controller controller, float duration, float amplitude, float frequency)
    {
        OVRInput.SetControllerVibration(frequency, amplitude, controller);
        yield return new WaitForSeconds(duration);
        OVRInput.SetControllerVibration(0f, 0f, controller);
    }
}