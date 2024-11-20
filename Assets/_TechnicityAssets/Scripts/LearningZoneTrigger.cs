using UnityEngine;
using UnityEngine.Video;

public class LearningZoneTrigger : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component on the screen

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the zone is the player (you may need to tag or layer the player appropriately)
        if (other.CompareTag("Player"))
        {
            StartVideo();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Stop the video when the player exits the zone
        if (other.CompareTag("Player"))
        {
            StopVideo();
        }
    }

    private void StartVideo()
    {
        videoPlayer.Play();
    }

    private void StopVideo()
    {
        videoPlayer.Stop();
    }
}
