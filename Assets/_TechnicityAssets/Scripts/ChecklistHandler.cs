using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChecklistManager : MonoBehaviour
{
    [System.Serializable]
    public class Task
    {
        public string description;         // Description of the task
        public GameObject checkmark;       // Reference to the checkmark UI element
        public bool isCompleted = false;   // To track task status
    }

    public List<Task> tasks;                  // List of tasks in the checklist
    public InputActionReference moveAction;   // Reference to Move action (joystick)
    public Camera mainCamera;                 // Main Camera for rotation detection
    public InputActionReference interactAction; // Optional: Action for interacting/grabbing objects

    private void OnEnable()
    {
        // Bind input actions
        moveAction.action.performed += OnMovePerformed;

        if (interactAction != null)
        {
            interactAction.action.performed += OnInteractPerformed;
        }
    }

    private void OnDisable()
    {
        // Unbind input actions
        moveAction.action.performed -= OnMovePerformed;

        if (interactAction != null)
        {
            interactAction.action.performed -= OnInteractPerformed;
        }
    }

    private void Update()
    {
        // Continuously check for turning around (headset/camera rotation)
        CheckTurnAround();
    }

    // 1. Handle Joystick Movement (Move Forward Task)
    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        Vector2 joystickInput = context.ReadValue<Vector2>();

        if (!tasks[0].isCompleted && joystickInput.y > 0.5f) // Forward movement threshold
        {
            Debug.Log("Move Forward Task Completed");
            CompleteTask(0); // Mark "Move Forward" task as completed
        }
    }

    // 2. Handle Turning Around (Headset Rotation)
    private void CheckTurnAround()
    {
        if (!tasks[1].isCompleted)
        {
            float cameraRotation = mainCamera.transform.eulerAngles.y;

            // Example: Detect ~180° turn
            if (cameraRotation > 170 && cameraRotation < 190)
            {
                Debug.Log("Turn Around Task Completed");
                CompleteTask(1); // Mark "Turn Around" task as completed
            }
        }
    }

    // 3. Handle Interactions (Optional: Grabbing Tools, etc.)
    private void OnInteractPerformed(InputAction.CallbackContext context)
    {
        // Assuming the third task corresponds to grabbing an object
        if (!tasks[2].isCompleted)
        {
            Debug.Log("Interaction Task Completed");
            CompleteTask(2); // Mark task (e.g., grabbing a hammer) as completed
        }
    }

    // Common Function to Mark a Task as Completed
    private void CompleteTask(int index)
    {
        if (index < 0 || index >= tasks.Count)
            return;

        tasks[index].isCompleted = true;
        tasks[index].checkmark.SetActive(true); // Show the checkmark for this task
    }
}
