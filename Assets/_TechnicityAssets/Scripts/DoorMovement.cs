using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [System.Serializable]
    public class DoorSettings
    {
        public Transform door;         // Reference to the door
        public float openAngle;        // Angle to open the door
        public float closeAngle = 0f;  // Default close angle
    }

    [SerializeField] private DoorSettings[] doors; // Array to store settings for each door
    public float rotationSpeed = 2f;               // Speed of the door rotation
    private bool isOpening = false;                // Check if the doors are opening or closing

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the entering object is the player
        {
            isOpening = true; // Start opening the doors
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player exits the trigger zone
        {
            isOpening = false; // Start closing the doors
        }
    }

    private void Update()
    {
        foreach (DoorSettings doorSetting in doors) // Loop through each door's settings
        {
            if (doorSetting.door != null)
            {
                // Smoothly rotate each door to its target angle
                float targetAngle = isOpening ? doorSetting.openAngle : doorSetting.closeAngle;
                Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);

                // Check if the door is close enough to the target angle
                if (Quaternion.Angle(doorSetting.door.rotation, targetRotation) > 0.1f)
                {
                    doorSetting.door.rotation = Quaternion.Slerp(doorSetting.door.rotation, targetRotation, Time.deltaTime * rotationSpeed);
                }
                else
                {
                    // Snap to the exact target rotation when close enough
                    doorSetting.door.rotation = targetRotation;
                }
            }
        }
    }
}
