using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClipboardController : MonoBehaviour
{
    public GameObject clipboard; // The clipboard GameObject to toggle
    public InputActionAsset inputActions; // Reference to your Input Action Asset

    private InputAction checklistAction; // Action to toggle clipboard visibility
    private bool isClipboardVisible = true; // Tracks whether the clipboard is visible

    private void OnEnable()
    {
        // Find the "Custom Buttons" action map and the "Checklist" action
        var customButtonsMap = inputActions.FindActionMap("Custom Buttons");
        checklistAction = customButtonsMap.FindAction("Checklist");

        // Subscribe to the performed event
        checklistAction.performed += OnToggleClipboard;
        checklistAction.Enable();
    }

    private void OnDisable()
    {
        // Unsubscribe from the performed event
        checklistAction.performed -= OnToggleClipboard;
        checklistAction.Disable();
    }

    private void OnToggleClipboard(InputAction.CallbackContext context)
    {
        // Toggle the clipboard's visibility
        isClipboardVisible = !isClipboardVisible;
        clipboard.SetActive(isClipboardVisible);
    }
}
