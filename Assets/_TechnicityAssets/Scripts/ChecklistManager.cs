using System.Collections;
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
        public GameObject targetObject;    // The specific object to grab for this task
    }

    public List<Task> tasks;                  // List of tasks in the checklist
    public InputActionReference moveAction;   // Reference to Move action (joystick)
    public Camera mainCamera;                 // Main Camera for rotation detection
    public InputActionReference interactAction; // Action for interacting/grabbing objects

    public GameObject tutorialChecklist;      // Reference to the tutorial checklist GameObject
    public GameObject chapter1Checklist;      // Reference to the chapter1 checklist GameObject

    private GameObject heldObject;            // Stores the currently held object (if any)

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

        // Check if all tasks are completed
        CheckAllTasksCompleted();
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
            if (cameraRotation > 150 && cameraRotation < 190)
            {
                Debug.Log("Turn Around Task Completed");
                CompleteTask(1); // Mark "Turn Around" task as completed
            }
        }
    }


    // 3. Handle Interactions (Grabbing Objects)
    private void OnInteractPerformed(InputAction.CallbackContext context)
    {
        if (heldObject != null)
        {
            // Check if the held object matches any of the tasks
            for (int i = 0; i < tasks.Count; i++)
            {
                if (!tasks[i].isCompleted && tasks[i].targetObject == heldObject)
                {
                    Debug.Log($"Task '{tasks[i].description}' Completed");
                    CompleteTask(i); // Mark task as completed
                    heldObject = null; // Release the held object after completing the task
                    return;
                }
            }
        }
    }

    // 4. Handle Picking Up Objects (Trigger or Collision)
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object matches any target object in the tasks
        foreach (var task in tasks)
        {
            if (!task.isCompleted && task.targetObject == other.gameObject)
            {
                Debug.Log($"Picked up: {other.gameObject.name}");
                heldObject = other.gameObject; // Assign the object as currently held
                return;
            }
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

    // Check if all tasks are completed
    private void CheckAllTasksCompleted()
    {
        foreach (var task in tasks)
        {
            if (!task.isCompleted)
            {
                return; // If any task is not completed, return
            }
        }

        // If all tasks are completed, switch checklists
        Debug.Log("All tasks in the tutorial checklist are completed!");

        if (tutorialChecklist != null && chapter1Checklist != null)
        {
            tutorialChecklist.SetActive(false); // Deactivate tutorial checklist
            chapter1Checklist.SetActive(true); // Activate chapter 1 checklist
        }
    }
}
