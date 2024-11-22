using UnityEngine;

public class HammerCollision : MonoBehaviour
{
    public GameObject[] nails; // Assign the Nail objects in sequence via Inspector
    private int currentIndex = 0;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is the current Nail
        if (currentIndex < nails.Length && other.gameObject == nails[currentIndex])
        {
            // Deactivate the current Nail
            nails[currentIndex].SetActive(false);

            // Activate the next Nail, if available
            currentIndex++;
            if (currentIndex < nails.Length)
            {
                nails[currentIndex].SetActive(true);
            }
        }
    }
}