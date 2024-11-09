using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class updater : MonoBehaviour
{
    public algo collisionDetector; // Reference to the GJKCollisionDetector component or algo class
    public TextMeshProUGUI uiText; // Use TextMeshProUGUI for TextMesh Pro

    void Start()
    {
        // Check if the collisionDetector is assigned
        if (collisionDetector == null)
        {
            Debug.LogError("collisionDetector (of type algo) is missing. Please assign it in the Inspector.");
        }

        // Check if uiText is assigned
        if (uiText == null)
        {
            Debug.LogError("TextMeshProUGUI component is missing from the GameObject. Please add and assign a TextMeshProUGUI component.");
        }
        else
        {
            // Initialize the text if uiText is assigned
            uiText.text = "No Collision";
        }
    }

    void Update()
    {
        // Check if both collisionDetector and uiText are assigned before updating
        if (collisionDetector != null && uiText != null)
        {
            uiText.text = collisionDetector.LastCollisionMessage;
        }
        else
        {
            // Additional debug logs to help identify the issue
            if (collisionDetector == null)
            {
                Debug.LogError("collisionDetector is not assigned.");
            }
            if (uiText == null)
            {
                Debug.LogError("uiText is not assigned.");
            }
        }
    }
}
