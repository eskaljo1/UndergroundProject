using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayLinkVideo : MonoBehaviour
{
    public string nameOfVideo;
    private VideoPlayer videoPlayer;

    void Awake()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
            videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, nameOfVideo + ".mp4");
            videoPlayer.prepareCompleted += (source) =>
            {
                source.Play();
            };
            videoPlayer.Prepare();
        }
    }

    void OnEnable()
    {
        if (videoPlayer.isPrepared)
            videoPlayer.Play();
        else
            videoPlayer.Prepare();
    }
}
