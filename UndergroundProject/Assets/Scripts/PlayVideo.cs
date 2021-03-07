using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public string nameOfVideo;
    private VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, nameOfVideo + ".webm");
    }
}
