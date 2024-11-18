using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

public class TutorialUIManager : MonoBehaviour
{
    public Canvas[] tutorialCanvases; // Assign GettingStarted, Familiarization, Checklist in this order
    private int currentCanvasIndex = 0;

    private bool buttonPressed = false;

    void Start()
    {
        // Ensure all canvases are disabled except the first one
        for (int i = 0; i < tutorialCanvases.Length; i++)
        {
            tutorialCanvases[i].gameObject.SetActive(i == 0);
        }
    }

    void Update()
    {
        // Listen for "Button A" input on the right controller
        if (XRInputReceived() && !buttonPressed)
        {
            buttonPressed = true; // Prevent rapid re-triggering
            CloseCurrentAndShowNext();
            StartCoroutine(ResetButtonPress()); // Reset button press after a small delay
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

    void CloseCurrentAndShowNext()
    {
        if (currentCanvasIndex < tutorialCanvases.Length)
        {
            // Deactivate the current canvas
            tutorialCanvases[currentCanvasIndex].gameObject.SetActive(false);

            // Move to the next canvas if it exists
            currentCanvasIndex++;
            if (currentCanvasIndex < tutorialCanvases.Length)
            {
                tutorialCanvases[currentCanvasIndex].gameObject.SetActive(true);
            }
        }
    }

    IEnumerator ResetButtonPress()
    {
        yield return new WaitForSeconds(0.2f); // Short delay to prevent button spamming
        buttonPressed = false;
    }
}
