using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRTeleportOnCollision : MonoBehaviour
{
    // The target position where you want to teleport the XR Rig
    [SerializeField] private Transform teleportTarget;

    // Reference to the XR Rig object (usually the main player object)
    [SerializeField] private GameObject xrRig;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with the trigger is the XR Rig
        if (other.gameObject == xrRig)
        {
            // Teleport the XR Rig to the target position
            xrRig.transform.position = teleportTarget.position;
            xrRig.transform.rotation = teleportTarget.rotation;
        }
    }
}
