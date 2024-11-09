using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class algo : MonoBehaviour
{
    private Vector3[] screwdriverPoints;
    [SerializeField] private TextMeshProUGUI collisionText; // Serialized for Inspector visibility

    public string LastCollisionMessage { get; private set; } = "No Collision";

    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();

        if (meshFilter != null && meshFilter.sharedMesh != null)
        {
            screwdriverPoints = GetWorldSpaceVertices(meshFilter);
            Debug.Log($"screwdriverPoints initialized with {screwdriverPoints.Length} points.");
        }
        else
        {
            Debug.LogError("MeshFilter or Mesh is missing on the GameObject. Make sure a mesh is assigned!");
        }

        if (collisionText != null)
        {
            collisionText.text = LastCollisionMessage;
        }
        else
        {
            Debug.LogError("collisionText is not assigned. Please assign a TextMeshProUGUI component in the Inspector.");
        }
    }

    void Update()
    {
        if (collisionText == null)
        {
            Debug.LogError("collisionText is still null in Update.");
            return;
        }

        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, 1f);
        Debug.Log($"Nearby objects detected: {nearbyObjects.Length}");

        bool collisionDetected = false;

        foreach (var obj in nearbyObjects)
        {
            var otherObject = obj.GetComponent<algo>();

            if (otherObject != null && GJK(screwdriverPoints, otherObject.screwdriverPoints))
            {
                collisionDetected = true;
                LastCollisionMessage = "Collision Detected";
                collisionText.text = LastCollisionMessage;
                Debug.Log("Collision Detected! Text updated.");
                break;
            }
        }

        if (!collisionDetected)
        {
            LastCollisionMessage = "No Collision";
            collisionText.text = LastCollisionMessage;
            Debug.Log("No Collision. Text updated.");
        }
    }

    private Vector3[] GetWorldSpaceVertices(MeshFilter filter)
    {
        Mesh mesh = filter.sharedMesh;
        Vector3[] localVertices = mesh.vertices;
        Vector3[] worldVertices = new Vector3[localVertices.Length];

        for (int i = 0; i < localVertices.Length; i++)
        {
            worldVertices[i] = filter.transform.TransformPoint(localVertices[i]);
            Debug.Log($"World Vertex {i}: {worldVertices[i]}");
        }
        return worldVertices;
    }

    private bool GJK(Vector3[] shape1, Vector3[] shape2)
    {
        Vector3 direction = shape1[0] - shape2[0];
        List<Vector3> simplex = new List<Vector3> { VectorMath.Support(shape1, shape2, direction) };
        direction = -simplex[0];

        while (true)
        {
            Vector3 A = VectorMath.Support(shape1, shape2, direction);
            if (Vector3.Dot(A, direction) <= 0) return false;

            simplex.Add(A);
            if (SimplexContainsOrigin(ref simplex, ref direction))
                return true;
        }
    }

    private bool SimplexContainsOrigin(ref List<Vector3> simplex, ref Vector3 direction)
    {
        Vector3 A = simplex[simplex.Count - 1];
        Vector3 AO = -A;

        if (simplex.Count == 3)
        {
            Vector3 B = simplex[1];
            Vector3 C = simplex[0];
            Vector3 AB = B - A;
            Vector3 AC = C - A;

            Vector3 ABC = Vector3.Cross(AB, AC);

            if (Vector3.Dot(Vector3.Cross(ABC, AC), AO) > 0)
            {
                simplex.RemoveAt(1);
                direction = Vector3.Cross(Vector3.Cross(AC, AO), AC);
            }
            else if (Vector3.Dot(Vector3.Cross(AB, ABC), AO) > 0)
            {
                simplex.RemoveAt(0);
                direction = Vector3.Cross(Vector3.Cross(AB, AO), AB);
            }
            else
            {
                direction = Vector3.Dot(ABC, AO) > 0 ? ABC : -ABC;
                if (direction == -ABC)
                {
                    simplex[0] = B;
                    simplex[1] = C;
                }
            }
        }
        else
        {
            Vector3 B = simplex[0];
            Vector3 AB = B - A;
            direction = Vector3.Cross(Vector3.Cross(AB, AO), AB);
        }

        return false;
    }
}

public static class VectorMath
{
    public static Vector3 Support(Vector3[] shape1, Vector3[] shape2, Vector3 direction)
    {
        Vector3 point1 = FindFurthestPointInDirection(shape1, direction);
        Vector3 point2 = FindFurthestPointInDirection(shape2, -direction);
        return point1 - point2;
    }

    private static Vector3 FindFurthestPointInDirection(Vector3[] shape, Vector3 direction)
    {
        float maxDot = float.MinValue;
        Vector3 furthestPoint = Vector3.zero;

        foreach (Vector3 point in shape)
        {
            float dot = Vector3.Dot(point, direction);
            if (dot > maxDot)
            {
                maxDot = dot;
                furthestPoint = point;
            }
        }

        return furthestPoint;
    }
}
