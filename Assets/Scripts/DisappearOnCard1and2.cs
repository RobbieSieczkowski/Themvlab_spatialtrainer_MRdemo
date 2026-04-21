using UnityEngine;

public class DisappearOnCard1and2 : MonoBehaviour
{
    public GameObject targetObject1;
    public GameObject targetObject2;
    public GameObject targetObject3;
    public GameObject targetObject4;

    void Update()
    {
        bool hideTriggered = IsActive(targetObject1) || IsActive(targetObject2);
        bool showTriggered = IsActive(targetObject3) || IsActive(targetObject4);

        if (hideTriggered && gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else if (showTriggered && !gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
    }

    private bool IsActive(GameObject obj)
    {
        return obj != null && obj.activeInHierarchy;
    }
}
