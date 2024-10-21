using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRCylinderTarget : MonoBehaviour
{
    // Reference to the player's XR rig camera (the headset)
    public Transform playerHeadset;

    // Distance at which the cylinder disappears
    public float disappearDistance = 1.5f;

    // Reference to the Canvases
    public GameObject tutorialCanvas;  // The canvas to deactivate
    public GameObject tutorialChapter2;  // The canvas to activate

    void Update()
    {
        // Calculate distance between player headset and cylinder
        float distance = Vector3.Distance(playerHeadset.position, transform.position);

        // If the player is close enough, make the cylinder disappear
        if (distance <= disappearDistance)
        {
            // Disable the TutorialChapter canvas
            tutorialCanvas.SetActive(false);

            // Activate the Chapters canvas
            tutorialChapter2.SetActive(true);

            // Destroy the cylinder (or you can disable it instead)
            Destroy(gameObject); // Cylinder disappears
        }
    }

    // If you want the player to be able to "select" the cylinder with a controller:
    public void OnSelectEnter(XRBaseInteractor interactor)
    {
        // Disable the TutorialChapter canvas
        tutorialCanvas.SetActive(false);

        // Activate the Chapters canvas
        tutorialChapter2.SetActive(true);

        // Destroy the cylinder when selected with VR controller
        Destroy(gameObject);
    }
}
