using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class RandomVideos : MonoBehaviour
{
    public VideoClip[] videoClips; // assign in inspector
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        if (videoClips.Length > 0)
        {
            int randomIndex = Random.Range(0, videoClips.Length);
            videoPlayer.clip = videoClips[randomIndex];
            videoPlayer.Play();
        }
        else
        {
            Debug.LogWarning("No video clips assigned!");
        }
    }
}
