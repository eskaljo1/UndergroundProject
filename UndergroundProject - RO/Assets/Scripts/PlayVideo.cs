using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public string nameOfVideo;
    private VideoPlayer videoPlayer;
    public GameObject skip;
    
    public float fadeOutAfterTime;
    public float fadeInAfterTime;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        videoPlayer.prepareCompleted += (source) =>
        {
            source.Play();
            StartCoroutine(FadeIn());
            //StartCoroutine(FadeOut());
        };

        videoPlayer.Prepare();
    }
    
    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnMovieFinished;
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, nameOfVideo + ".webm");
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(fadeOutAfterTime);
        while(spriteRenderer.color.a > 0.0f)
        {
            Color newColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a - 0.066f);
            spriteRenderer.color = newColor;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(fadeInAfterTime);
        while (spriteRenderer.color.a < 1.0f)
        {
            Color newColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a + 0.066f);
            spriteRenderer.color = newColor;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void OnMovieFinished(VideoPlayer player)
    {
        SkipVideo script = (SkipVideo) skip.GetComponent(typeof(SkipVideo));//delete this when MP
        script.Skip();
    }

}
