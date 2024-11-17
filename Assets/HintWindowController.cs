using UnityEngine;
using UnityEngine.InputSystem;

public class HintWindowController : MonoBehaviour
{
    public GameObject hintWindow;   // The HintWindow panel to show/hide
    private bool isHintVisible = false;   // Tracks if the hint is visible

    void Update()
    {
        // Check if Button A on the controller is pressed
        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            // Hide the hint window if it's currently visible
            if (isHintVisible)
            {
                HideHint();
            }
        }
    }

    // Method to show the hint window when Tip1 button is clicked
    public void ShowHint()
    {
        hintWindow.SetActive(true);
        isHintVisible = true;
    }

    // Method to hide the hint window
    public void HideHint()
    {
        hintWindow.SetActive(false);
        isHintVisible = false;
    }
}
