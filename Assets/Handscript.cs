using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class TutorialToggleUI_XR : MonoBehaviour
{
    public GameObject tutorialCanvas; // Reference to the Canvas UI GameObject
    private bool isTutorialActive = true; // State of UI visibility
    private InputDevice targetDevice;

    void Start()
    {
        // Ensure the tutorial canvas is active at the start
        tutorialCanvas.SetActive(isTutorialActive);

        // Initialize the target device for the left hand controller
        var leftHandedDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, leftHandedDevices);

        if (leftHandedDevices.Count > 0)
        {
            targetDevice = leftHandedDevices[0];
        }
    }

    void Update()
    {
        // Check if the X button (secondary button) is pressed on the target device
        if (targetDevice.isValid && targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool isPressed) && isPressed)
        {
            // Toggle the visibility of the tutorial canvas when X button is pressed
            isTutorialActive = !isTutorialActive;
            tutorialCanvas.SetActive(isTutorialActive);

            // Small delay to prevent rapid toggling
            Invoke(nameof(ResetPress), 0.25f);
        }

        // If you want the canvas to follow the left hand controller's position and rotation:
        if (targetDevice.isValid && tutorialCanvas.activeSelf)
        {
            // Update the position and rotation of the canvas to match the left hand
            var position = new Vector3();
            var rotation = new Quaternion();

            if (targetDevice.TryGetFeatureValue(CommonUsages.devicePosition, out position) &&
                targetDevice.TryGetFeatureValue(CommonUsages.deviceRotation, out rotation))
            {
                tutorialCanvas.transform.position = position;
                tutorialCanvas.transform.rotation = rotation;
            }
        }
    }

    private void ResetPress()
    {
        // Reset button press detection to avoid toggling on a long press
        targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out _);
    }
}
