using UnityEngine;

public class CardVisController : MonoBehaviour
{
    public GameObject objectToToggle;   // the button/object you want to hide/show
    public GameObject targetObject1;
    public GameObject targetObject2;
    public GameObject targetObject3;
    public GameObject targetObject4;

    void Update()
    {
        bool hideTriggered = IsActive(targetObject1) || IsActive(targetObject2);
        bool showTriggered = IsActive(targetObject3) || IsActive(targetObject4);

        if (hideTriggered) objectToToggle.SetActive(false);
        else if (showTriggered) objectToToggle.SetActive(true);
    }

    private bool IsActive(GameObject obj)
    {
        return obj != null && obj.activeInHierarchy;
    }
}
