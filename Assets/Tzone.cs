using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject door; // Assign your door GameObject in the Inspector
    public Vector3 openPosition; // The target position when the door is open
    public float openSpeed = 3f; // Speed of door opening

    private Vector3 closedPosition;

    private void Start()
    {
        // Store the door's initial closed position
        closedPosition = door.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines(); // Stop any ongoing animations
            StartCoroutine(MoveDoor(openPosition));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines(); // Stop any ongoing animations
            StartCoroutine(MoveDoor(closedPosition));
        }
    }

    private System.Collections.IEnumerator MoveDoor(Vector3 targetPosition)
    {
        while (Vector3.Distance(door.transform.position, targetPosition) > 0.01f)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, targetPosition, openSpeed * Time.deltaTime);
            yield return null;
        }
        door.transform.position = targetPosition; // Snap to final position
    }
}
