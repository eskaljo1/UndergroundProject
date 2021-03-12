using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public string nameOfVideo;
    private VideoPlayer videoPlayer;
    public GameObject skip;

    public GameObject link;

    // Start is called before the first frame update
    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnMovieFinished;
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, nameOfVideo + ".webm");
        videoPlayer.Play();
        if (link != null)
            link.SetActive(true);
    }


    void OnMovieFinished(VideoPlayer player)
    {
        SkipVideo script = (SkipVideo) skip.GetComponent(typeof(SkipVideo));//delete this when MP
        script.OnMouseDown();
    }

}
