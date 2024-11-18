using UnityEngine;

public class NailInteraction : MonoBehaviour
{
    public float movementSpeed = 0.1f; // Speed at which the nail moves down
    public float maxDepth = -1f;      // Maximum depth the nail can reach

    private bool isHit = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hammer"))
        {
            isHit = true;
        }
    }

    private void Update()
    {
        if (isHit)
        {
            // Move the nail downward
            if (transform.position.y > maxDepth)
            {
                transform.position += Vector3.down * movementSpeed * Time.deltaTime;
            }
            else
            {
                isHit = false; // Stop moving when max depth is reached
            }
        }
    }
}
