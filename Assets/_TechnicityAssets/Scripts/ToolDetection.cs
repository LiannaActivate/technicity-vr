using UnityEngine;
using UnityEngine.Video;

public class ToolDetection : MonoBehaviour
{
    public Transform tool; // Reference to the screwdriver tool (drag in the Inspector)
    public float detectionDistance = 1.5f; // Set distance for the tool to be considered "pointing"
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component on the screen

    private bool isPlaying = false;

    void Update()
    {
        CheckToolPosition();
    }

    private void CheckToolPosition()
    {
        Vector3 directionToScreen = (transform.position - tool.position).normalized;

        if (Vector3.Distance(tool.position, transform.position) <= detectionDistance)
        {
            if (Vector3.Dot(tool.forward, directionToScreen) > 0.7f)
            {
                if (!isPlaying)
                {
                    Debug.Log("Tool detected - Playing video");
                    PlayVideo();
                }
            }
            else
            {
                if (isPlaying)
                {
                    Debug.Log("Tool no longer pointing - Stopping video");
                    StopVideo();
                }
            }
        }
        else
        {
            if (isPlaying)
            {
                Debug.Log("Tool out of range - Stopping video");
                StopVideo();
            }
        }
    }


    private void PlayVideo()
    {
        // Set the VideoPlayer to render on the material
        videoPlayer.targetMaterialRenderer = GetComponent<Renderer>();
        videoPlayer.targetMaterialProperty = "_MainTex";
        videoPlayer.Play();
        isPlaying = true;
    }


    private void StopVideo()
    {
        videoPlayer.Stop();
        isPlaying = false;
    }
}
