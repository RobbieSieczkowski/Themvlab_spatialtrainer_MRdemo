using UnityEngine;

/// <summary>
/// When any of the four trigger inputs (L/R Grab/Trigger) is pressed,
/// measures the current distance between the two controllers and applies
/// that distance as a uniform scale to the target Kinesphere GameObject.
///
/// No continuous tracking, no clamps. The user picks the scale explicitly
/// by posing and pressing a trigger.
/// </summary>
public class KinesphereCalibrator : MonoBehaviour
{
    [Header("Controller References")]
    [Tooltip("The Left controller transform (e.g. LeftHand Controller).")]
    [SerializeField] private Transform leftController;

    [Tooltip("The Right controller transform (e.g. RightHand Controller).")]
    [SerializeField] private Transform rightController;

    [Header("Target")]
    [Tooltip("The Kinesphere parent GameObject -- its localScale is set uniformly to the measured wingspan.")]
    [SerializeField] private Transform kinesphereTarget;

    [Header("Options")]
    [Tooltip("Multiplier applied on top of the measured distance before setting scale. 1.0 = wingspan in meters maps 1:1 to scale units.")]
    [SerializeField] private float scaleMultiplier = 1f;

    [Tooltip("If true, logs each calibration event to the Console.")]
    [SerializeField] private bool logCalibration = false;

    void Update()
    {
        // Any of the four trigger inputs triggers a single calibration event on press-down.
        // Using GetDown (not Get) so holding the trigger doesn't spam continuous scaling.
        bool anyTriggerPressed =
            OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) ||
            OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch) ||
            OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) ||
            OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch);

        if (anyTriggerPressed)
        {
            Calibrate();
        }
    }

    /// <summary>Measure wingspan and apply it to the Kinesphere. Safe to call from UI buttons too.</summary>
    public void Calibrate()
    {
        if (leftController == null || rightController == null || kinesphereTarget == null)
        {
            Debug.LogWarning("[Kinesphere] Missing reference(s) -- cannot calibrate.", this);
            return;
        }

        float wingspan = Vector3.Distance(leftController.position, rightController.position);
        float scale = wingspan * scaleMultiplier;

        kinesphereTarget.localScale = new Vector3(scale, scale, scale);

        if (logCalibration)
        {
            Debug.Log($"[Kinesphere] Calibrated. wingspan={wingspan:F2}m, scale={scale:F2}");
        }
    }
}