using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ExitSceneController : MonoBehaviour
{
    public InputActionAsset inputActions; // Reference to your Input Action Asset
    private InputAction exitSceneAction; // Action for exiting the scene

    private void OnEnable()
    {
        // Find the "Custom Buttons" action map and the "Exit Scene" action
        var customButtonsMap = inputActions.FindActionMap("Custom Buttons");
        exitSceneAction = customButtonsMap.FindAction("Exit Scene");

        // Subscribe to the performed event
        exitSceneAction.performed += OnExitScene;
        exitSceneAction.Enable();
    }

    private void OnDisable()
    {
        // Unsubscribe from the performed event
        exitSceneAction.performed -= OnExitScene;
        exitSceneAction.Disable();
    }

    private void OnExitScene(InputAction.CallbackContext context)
    {
        // Load the Main Menu Scene (Scene 02)
        SceneManager.LoadScene(2); // Replace "2" with your Main Menu Scene index
    }
}
