using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Circulates between three Laban shapes, deactivating the current shape and activating the next in the cycle
// Includes a fourth, no-shape option; this is the default

public class CirculateShapes : MonoBehaviour
{
    private int pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = 0;
    }

        // Update is called once per frame
        void Update()
    {
 //       if (!PauseMenu.isPaused)
        {
            // Circulates to the next shape when the user presses the "A" button on the Oculus Touch controller or Spacebar on the keyboard
            if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Space))
            {
                if (pos == 0)
                {
                    Debug.Log("Switching to: Cube");
                    transform.GetChild(0).gameObject.SetActive(true);
                    pos++;
                }
                else if (pos == 1)
                {
                    Debug.Log("Switching to: Octahedron");
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(true);
                    pos++;
                }
                else if (pos == 2)
                {
                    Debug.Log("Switching to: Icosahedron");
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(true);
                    pos++;
                }
                else
                {
                    Debug.Log("Switching to: No shape");
                    transform.GetChild(2).gameObject.SetActive(false);
                    pos = 0;
                }
            }
        }
    }

    // Deactivates all platonic solids upon completion of data playback
    private void OnDisable()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        pos = 0;
    }
}
