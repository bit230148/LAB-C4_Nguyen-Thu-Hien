using UnityEngine;
using UnityEngine.Video;

public class VideoEventsController : MonoBehaviour
{
    public VideoPlayer vp;
    public GameObject endUI;

    void Start()
    {
        if (!vp)
            vp = GetComponent<VideoPlayer>();

        if (endUI)
            endUI.SetActive(false);

        vp.loopPointReached += OnVideoEnd;
        vp.Play();
    }

    void OnVideoEnd(VideoPlayer source)
    {
        Debug.Log("VIDEO ENDED");
        if (endUI)
            endUI.SetActive(true);
    }

    void OnDestroy()
    {
        if (vp)
            vp.loopPointReached -= OnVideoEnd;
    }
}
