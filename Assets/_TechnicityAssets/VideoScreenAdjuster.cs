using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video; // Import the namespace for VideoPlayer

public class VideoScreenAdjuster : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component
    public Transform screenTransform; // Reference to the screen's Transform

    void Start()
    {
        if (videoPlayer.clip != null)
        {
            // Calculate the aspect ratio of the video
            float videoAspect = (float)videoPlayer.clip.width / videoPlayer.clip.height;

            // Adjust the scale of the screen
            screenTransform.localScale = new Vector3(videoAspect, 1, 1);
        }
    }
}
