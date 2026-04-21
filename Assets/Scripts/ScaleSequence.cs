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

    [SerializeField] private AudioClip a;
    [SerializeField] private AudioClip b;
    [SerializeField] private AudioClip c;
    [SerializeField] private AudioClip d;
    [SerializeField] private AudioClip e;
    [SerializeField] private AudioClip f;
    [SerializeField] private AudioClip g;

    public bool isScaffoldedMode;

    [SerializeField] private AudioClip voiceoverTrack;

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

        isScaffoldedMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        // This activates on either controller, not just Right or Left
        if (rightHandScaleActive && (currentBeat.GetComponent<TouchMe>().CollisionDetector() == "Right"))
        {
            ScaleProgressor();
        } else if (leftHandScaleActive && currentBeat.GetComponent<TouchMe>().CollisionDetector() == "Left")
        {
            ScaleProgressor();
        }

        // Switch between Right and Left Handed mode
        if ((OVRInput.GetDown(OVRInput.Button.One) || OVRInput.GetDown(OVRInput.Button.Two)) && count == 0)
        {
            LeftOrRight(true);
        }
        if ((OVRInput.GetDown(OVRInput.Button.Three) || OVRInput.GetDown(OVRInput.Button.Four)) && count == 0)
        {
            LeftOrRight(false);
        }

        // Play tutorial VO's on Playing

        if (isScaffoldedMode)
        {
            StartCoroutine(WaitThenDoSomething());
            SoundManager.instance.PlaySoundClip(voiceoverTrack, transform, 1f);
        }
    }

    public void LeftOrRight(bool rOrL)
    {
        ResetState();

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
    }

    void SetScaleSequences()
    {
        // Dimensional
        
        dimensionalScaleRightHand = new List<GameObject>() { high, deep, right, left, forward, backward };
        dimensionalScaleLeftHand = new List<GameObject>() { high, deep, left, right, forward, backward };
        dimensionalScaleChords = new List<AudioClip>() { c, d, e, f, g, a };

        // Diagonal

        diagonalScaleRightHand = new List<GameObject>() { highRightForward, deepLeftBackward, highLeftForward , deepRightBackward, highLeftBackward, deepRightForward, highRightBackward, deepLeftForward };
        diagonalScaleLeftHand = new List<GameObject>() { highLeftForward, deepRightBackward, highRightForward, deepLeftBackward, highRightBackward, deepLeftForward, highLeftBackward, deepRightForward };
        dimensionalScaleChords = new List<AudioClip>() { a, b, c, d, e, f, g, a };

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
        ResetState();

        if (index == 0)
        {
            if (rightHandScaleActive)
            {
                currentScale = dimensionalScaleRightHand;
            } else
            {
                currentScale = dimensionalScaleLeftHand;
            }
        } else if (index == 1)
        {
            if (rightHandScaleActive)
            {
                currentScale = diagonalScaleRightHand;
            }
            else
            {
                currentScale = diagonalScaleLeftHand;
            }
        } else if (index == 2)
        {
            if (rightHandScaleActive)
            {
                currentScale = axisScaleRightHand;
            }
            else
            {
                currentScale = axisScaleLeftHand;
            }
        } else if (index == 3)
        {
            if (rightHandScaleActive)
            {
                currentScale = girdleScaleRightHand;
            }
            else
            {
                currentScale = girdleScaleLeftHand;
            }
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

    IEnumerator WaitThenDoSomething()
    {
        Debug.Log("Waiting...");
        yield return new WaitForSeconds(3f);
        Debug.Log("3 seconds later!");
    }

    public void ResetState()
    {
        count = 0;

        currentBeat = currentScale[0];
    }
}
