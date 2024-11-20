using UnityEngine;

public class DrillScrewInteraction : MonoBehaviour
{
    public float ScrewSpeed = 0.1f; // Speed at which the screw moves down
    public Vector3 ScrewDirection = Vector3.down; // Direction of movement

    private DrillTrigger drillTrigger;

    private void OnTriggerEnter(Collider other)
    {
        drillTrigger = other.GetComponentInParent<DrillTrigger>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (drillTrigger != null && drillTrigger.IsDrilling)
        {
            transform.position += ScrewDirection * ScrewSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (drillTrigger != null && other.GetComponentInParent<DrillTrigger>() != null)
        {
            drillTrigger = null;
        }
    }
}