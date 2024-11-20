using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

public class HintUIManager : MonoBehaviour
{
    public GameObject[] hintWindows; // Assign the hint windows for each task in the Inspector
    private GameObject currentHintWindow = null; // Tracks the currently open hint window

    private bool buttonPressed = false;

    void Start()
    {
        // Ensure all hint windows are initially inactive
        foreach (GameObject hintWindow in hintWindows)
        {
            hintWindow.SetActive(false);
        }
    }

    void Update()
    {
        // Listen for "Button A" input on the right controller
        if (XRInputReceived() && currentHintWindow != null && !buttonPressed)
        {
            buttonPressed = true; // Prevent rapid re-triggering
            CloseCurrentHint();
            StartCoroutine(ResetButtonPress()); // Reset button press after a short delay
        }
    }

    bool XRInputReceived()
    {
        InputDevice rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if (rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPressed))
        {
            return isPressed;
        }
        return false;
    }

    public void OpenHint(int hintIndex)
    {
        // Close the currently open hint window, if any
        if (currentHintWindow != null)
        {
            currentHintWindow.SetActive(false);
        }

        // Open the selected hint window
        currentHintWindow = hintWindows[hintIndex];
        currentHintWindow.SetActive(true);
    }

    void CloseCurrentHint()
    {
        if (currentHintWindow != null)
        {
            currentHintWindow.SetActive(false);
            currentHintWindow = null; // Reset the current hint window
        }
    }

    IEnumerator ResetButtonPress()
    {
        yield return new WaitForSeconds(0.2f); // Short delay to prevent button spamming
        buttonPressed = false;
    }
}
