using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMe : MonoBehaviour
{
    private string value;
    private string newValue;

    void Start()
    {
        value = "Neither";
        newValue = "Neither";
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // Diagnostic: log exactly what collided, its tag, and its parent's tag
        string parentTag = other.transform.parent != null ? other.transform.parent.tag : "(no parent)";
        Debug.Log($"COLLISION | name={other.gameObject.name} | tag={other.gameObject.tag} | parent.tag={parentTag}");

        // Walk up the hierarchy to find a RightHand or LeftHand tag.
        // Handles the common case where the collider sits on a child of the tagged controller.
        string detected = FindHandTagInAncestors(other.transform);

        if (detected == "RightHand")
        {
            value = "Right";
            Debug.Log("RIGHT HAND DETECTED");
        }
        else if (detected == "LeftHand")
        {
            value = "Left";
            Debug.Log("LEFT HAND DETECTED");
        }
        else
        {
            Debug.Log("NEITHER HAND DETECTED - check controller tagging");
        }
    }

    private string FindHandTagInAncestors(Transform start)
    {
        Transform current = start;
        while (current != null)
        {
            if (current.CompareTag("RightHand")) return "RightHand";
            if (current.CompareTag("LeftHand")) return "LeftHand";
            current = current.parent;
        }
        return null;
    }

    public string CollisionDetector()
    {
        newValue = value;
        newValue = value;
        value = "Neither";
        return newValue;
    }
}