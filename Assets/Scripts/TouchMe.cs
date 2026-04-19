using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMe : MonoBehaviour
{
    private string value;
    private string newValue;

    // Start is called before the first frame update
    void Start()
    {
        value = "Neither";
        newValue = "Neither";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLISION");
        // Temporary fix
        value = "Right";
        if (other.gameObject.tag == "RightHand") // NOT WORKING
        {
            value = "Right";
            Debug.Log("RIGHT HAND TAG");
        } else if (other.gameObject.tag == "LeftHand") // NOT WORKING
        {
            value = "Left";
            Debug.Log("LEFT HAND TAG");
        }
    }

    public string CollisionDetector()
    {
        newValue = value;
        value = "Neither";
        return newValue;
    }
}
