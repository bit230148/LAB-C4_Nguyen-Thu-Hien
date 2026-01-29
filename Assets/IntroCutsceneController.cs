using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroCutsceneController : MonoBehaviour
{
    [Header("Refs")]
    public VideoPlayer vp;
    public AudioSource bgm;

    [Header("Scene index in Build Settings")]
    public int gameplaySceneIndex = 1; // gameplay là scene 1

    bool isEnding = false;

    void Awake()
    {
        if (!vp) vp = GetComponent<VideoPlayer>();
    }

    void OnEnable()
    {
        vp.prepareCompleted += OnPrepared;
        vp.loopPointReached += OnVideoFinished;
    }

    void OnDisable()
    {
        vp.prepareCompleted -= OnPrepared;
        vp.loopPointReached -= OnVideoFinished;
    }

    void Start()
    {
        vp.isLooping = false;
        vp.playOnAwake = false;

        if (bgm)
        {
            bgm.playOnAwake = false;
            bgm.loop = true;
        }

        vp.Prepare();
    }

    void OnPrepared(VideoPlayer _)
    {
        if (isEnding) return;
        if (bgm) bgm.Play();
        vp.Play();
    }

    void OnVideoFinished(VideoPlayer _)
    {
        GoToGameplay();
    }

    public void Skip()
    {
        GoToGameplay();
    }

    void GoToGameplay()
    {
        if (isEnding) return;
        isEnding = true;

        if (vp) vp.Stop();
        if (bgm) bgm.Stop();

        SceneManager.LoadScene(gameplaySceneIndex);
    }
}
