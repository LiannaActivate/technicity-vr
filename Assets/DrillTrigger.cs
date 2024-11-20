using UnityEngine;

public class DrillTrigger : MonoBehaviour
{
    public bool IsDrilling { get; private set; }

    public void StartDrilling()
    {
        IsDrilling = true;
        Debug.Log("Drill started.");
    }

    public void StopDrilling()
    {
        IsDrilling = false;
        Debug.Log("Drill stopped.");
    }
}