using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChecklistUIManager : MonoBehaviour
{
    [System.Serializable]
    public class Task
    {
        public string description;
        public GameObject checkmark; // Reference to the checkmark UI element
        public bool isCompleted = false; // To track task status
    }

    public List<Task> tasks; // List of tasks

    // Update is called once per frame
    void Update()
    {
        // Example tasks
        if (!tasks[0].isCompleted && CheckMoveForward())
        {
            CompleteTask(0); // First task: Move forward
        }
        if (!tasks[1].isCompleted && CheckTurnAround())
        {
            CompleteTask(1); // Second task: Turn around
        }
    }

    void CompleteTask(int index)
    {
        tasks[index].isCompleted = true;
        tasks[index].checkmark.SetActive(true); // Show the checkmark
    }

    bool CheckMoveForward()
    {
        // Replace with your XR input check for left joystick forward movement
        return Input.GetAxis("Vertical") > 0;
    }

    bool CheckTurnAround()
    {
        // Check if the player has turned around based on MainCamera rotation
        float cameraRotation = Camera.main.transform.eulerAngles.y;
        return cameraRotation > 170 && cameraRotation < 190; // Example: detect ~180° turn
    }
}
