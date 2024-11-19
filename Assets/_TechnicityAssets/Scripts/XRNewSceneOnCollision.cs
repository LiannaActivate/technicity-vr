using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Import Scene Management

public class XRNewSceneOnCollision : MonoBehaviour
{
    // Reference to the XR Rig object (usually the main player object)
    [SerializeField] private GameObject xrRig;

    // The index of the scene to load (e.g., Scene 4)
    [SerializeField] private int sceneToLoad = 4;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with the trigger is the XR Rig
        if (other.gameObject == xrRig)
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
