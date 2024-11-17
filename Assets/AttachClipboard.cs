using UnityEngine;
using UnityEngine.XR;

public class ClipboardManager : MonoBehaviour
{
    public Transform leftHandController; // Assign this in the inspector to your left hand controller object
    public GameObject clipboard;

    void Start()
    {
        if (clipboard.transform.parent != leftHandController)
        {
            clipboard.transform.SetParent(leftHandController);
            clipboard.transform.localPosition = Vector3.zero;
            clipboard.transform.localRotation = Quaternion.identity;
        }
    }
}
