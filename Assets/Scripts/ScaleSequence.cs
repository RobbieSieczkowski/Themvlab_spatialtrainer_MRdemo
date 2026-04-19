using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSequence : MonoBehaviour
{
    static private List<GameObject> testScale;
    static private List<GameObject> dimensionalScaleRightHand;
    static private List<GameObject> dimensionalScaleLeftHand;
    static private List<AudioClip> dimensionalScaleChords;
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
    public GameObject hightRightBackward;
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

    [SerializeField] private AudioClip a;
    [SerializeField] private AudioClip b;
    [SerializeField] private AudioClip c;
    [SerializeField] private AudioClip d;
    [SerializeField] private AudioClip e;
    [SerializeField] private AudioClip f;
    [SerializeField] private AudioClip g;

    // Start is called before the first frame update
    void Start()
    {
        SetScaleSequences();

        currentScale = dimensionalScaleRightHand;
        currentBeat = currentScale[0];

        currentBeat.transform.GetChild(0).gameObject.SetActive(true);

        count = 0;

        rightHandScaleActive = true;
        leftHandScaleActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rightHandScaleActive && (currentBeat.GetComponent<TouchMe>().CollisionDetector() == "Right"))
        {
            ScaleProgressor();
        } else if (leftHandScaleActive && currentBeat.GetComponent<TouchMe>().CollisionDetector() == "Left")
        {
            ScaleProgressor();
        }

        // Temporary scale switch; only works if scale has not been played yet
        /*
        if (OVRInput.GetDown(OVRInput.Button.One) && count == 0)
        {
            if (rightHandScaleActive)
            {
                currentScale = dimensionalScaleRightHand;
                rightHandScaleActive = true;
                leftHandScaleActive = false;
            }
            else
            {
                currentScale = dimensionalScaleLeftHand;
                rightHandScaleActive = false;
                leftHandScaleActive = true;
            }
        }
        */

        SelectScale();
    }

    void SetScaleSequences()
    {
        testScale = new List<GameObject>() { forward, backward, forward, backward, forward, backward };
        dimensionalScaleRightHand = new List<GameObject>() { high, deep, left, right, forward, backward };
        dimensionalScaleLeftHand = new List<GameObject>() { high, deep, right, left, forward, backward };
        dimensionalScaleChords = new List<AudioClip>() { c, d, e, f, g, a };
    }

    void SelectScale()
    {
        if (false) // scale button select needed
        {
            currentScale = dimensionalScaleRightHand;
            rightHandScaleActive = true;
            leftHandScaleActive = false;
        } else if (false) // scale button select needed
        {
            currentScale = dimensionalScaleLeftHand;
            rightHandScaleActive = false;
            leftHandScaleActive = true;
        }
    }

    void ScaleProgressor()
    {
        Debug.Log("SCALE PROGRESSION");
        currentBeat.transform.GetChild(0).gameObject.SetActive(false);
        //currentBeat.SetActive(false);
        if (count < currentScale.Count - 1)
        {
            SoundManager.instance.PlaySoundClip(dimensionalScaleChords[count], currentBeat.transform, 1f);

            count = count + 1;
            currentBeat = currentScale[count];
            currentBeat.transform.GetChild(0).gameObject.SetActive(true);
        } else
        {
            //SoundManager.instance.PlaySoundClip(b, currentBeat.transform, 1f);
            Debug.Log("REPEAT");
            currentBeat = currentScale[0];
            currentBeat.transform.GetChild(0).gameObject.SetActive(true);
            //Debug.Log("END");
            //currentBeat = null;
            //currentScale = null;
            count = 0;
        }
    }
}
