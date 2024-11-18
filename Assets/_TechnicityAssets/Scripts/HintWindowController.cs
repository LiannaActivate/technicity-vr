using UnityEngine;
using UnityEngine.InputSystem;

public class HintWindowController : MonoBehaviour
{
    public GameObject hintWindow;   // The HintWindow panel to show/hide
    private bool isHintVisible = false;   // Tracks if the hint is visible

    void Update()
    {
        // Check if Button A on the right-hand controller is pressed (PrimaryButton for XRController)
        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            // Hide the hint window if it's currently visible
            if (isHintVisible)
            {
                HideHint();
            }
        }
    }

    // Method to show the hint window when the UI button is clicked
    public void ShowHint()
    {
        hintWindow.SetActive(true);  // Activate the UI window
        isHintVisible = true;       // Update state to indicate hint is visible
    }

    // Method to hide the hint window
    public void HideHint()
    {
        hintWindow.SetActive(false);  // Deactivate the UI window
        isHintVisible = false;       // Update state to indicate hint is not visible
    }

    // Method to toggle hint window (optional, if needed for other interactions)
    public void ToggleHint()
    {
        if (isHintVisible)
        {
            HideHint();
        }
        else
        {
            ShowHint();
        }
    }
}
