﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayLinkVideo : MonoBehaviour
{
    public string nameOfVideo;
    private VideoPlayer videoPlayer;
    
    void OnEnable()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, nameOfVideo + ".mp4");
        videoPlayer.Play();
    }

}
