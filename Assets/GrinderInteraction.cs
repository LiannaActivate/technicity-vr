using UnityEngine;

public class GrinderInteraction : MonoBehaviour
{
    public AudioSource grindingSound;  // Optional: Attach a grinding sound

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GrindableSurface"))
        {
            Debug.Log("Started grinding on surface.");
            if (grindingSound != null) grindingSound.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("GrindableSurface"))
        {
            Debug.Log("Grinding in progress...");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GrindableSurface"))
        {
            Debug.Log("Stopped grinding on surface.");
            if (grindingSound != null) grindingSound.Stop();
        }
    }
}
