using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSliding : MonoBehaviour
{
    [System.Serializable]
    public class DoorSettings
    {
        public Transform door;          // The door to slide
        public Vector3 openPosition;    // Position when the door is open
        public Vector3 closedPosition;  // Position when the door is closed
    }

    [SerializeField] private DoorSettings[] doors; // Array of doors
    public float moveSpeed = 2f;                   // Speed of the sliding motion

    private bool isOpening = false;               // Whether the door is opening
    private bool isClosing = false;               // Whether the door is closing

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpening = true;  // Start opening
            isClosing = false; // Cancel closing if triggered again
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isClosing = true;  // Start closing
            isOpening = false; // Cancel opening if exiting
        }
    }

    private void Update()
    {
        foreach (DoorSettings doorSetting in doors)
        {
            if (isOpening)
            {
                // Move the door towards its open position
                doorSetting.door.localPosition = Vector3.MoveTowards(
                    doorSetting.door.localPosition,
                    doorSetting.openPosition,
                    moveSpeed * Time.deltaTime
                );
            }
            else if (isClosing)
            {
                // Move the door towards its closed position
                doorSetting.door.localPosition = Vector3.MoveTowards(
                    doorSetting.door.localPosition,
                    doorSetting.closedPosition,
                    moveSpeed * Time.deltaTime
                );
            }
        }
    }
}
