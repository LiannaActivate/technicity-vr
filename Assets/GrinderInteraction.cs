using UnityEngine;

public class GrinderInteraction : MonoBehaviour
{
    public AudioSource grindingSound;  // Attach the grinding sound effect

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GrindableSurface"))
        {
            // Play audio effect
            if (grindingSound != null) grindingSound.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("GrindableSurface"))
        {
            // Handle continuous grinding effect
            Debug.Log("Grinding in progress...");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GrindableSurface"))
        {
            // Stop audio effect
            if (grindingSound != null) grindingSound.Stop();
        }
    }
}
