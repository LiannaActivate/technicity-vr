using UnityEngine;

public class Screw : MonoBehaviour
{
    public float screwSpeed = 0.02f; // Speed of the screw moving down
    public float maxDepth = -0.5f; // Maximum depth the screw can move down

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void Drill()
    {
        if (transform.position.y > initialPosition.y + maxDepth)
        {
            transform.position -= new Vector3(0, screwSpeed * Time.deltaTime, 0);
        }
    }
}
