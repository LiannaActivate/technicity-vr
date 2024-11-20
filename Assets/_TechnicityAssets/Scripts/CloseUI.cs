using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CloseUI : MonoBehaviour
{
    [SerializeField] private GameObject uiWindow; // Assign your UI window in the Inspector
    private InputAction closeUIAction;

    private void OnEnable()
    {
        // Bind to the Input Action
        closeUIAction = new InputAction(binding: "<XRController>{RightHand}/primaryButton");

        closeUIAction.performed += OnCloseUIPressed;
        closeUIAction.Enable();
    }

    private void OnDisable()
    {
        closeUIAction.performed -= OnCloseUIPressed;
        closeUIAction.Disable();
    }

    private void OnCloseUIPressed(InputAction.CallbackContext context)
    {
        if (uiWindow.activeSelf)
        {
            uiWindow.SetActive(false); // Close the UI
        }
    }
}
