using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMe : MonoBehaviour
{
    public GameObject player;
    public float minYPosition = 1f; // The minimum positive Y position to ensure the object stays above the ground

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player GameObject not assigned!");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Keep the object's Y position positive
            Vector3 currentPosition = transform.position;
            if (currentPosition.y < minYPosition)
            {
                currentPosition.y = minYPosition;
                transform.position = currentPosition; // Update the object's position to ensure Y is positive
            }

            // Get the player's position and lock the Y-axis for horizontal rotation
            Vector3 playerPosition = player.transform.position;
            playerPosition.y = transform.position.y; // Ensure we are only rotating horizontally

            // Make the object look at the player
            transform.LookAt(playerPosition);
        }
    }
}
