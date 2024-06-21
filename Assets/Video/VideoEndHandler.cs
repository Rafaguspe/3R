using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoEndHandler : MonoBehaviour
{
    public  VideoPlayer videoPlayer;
    public string scene;
    public Button saltar;

    void Start()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoEnd;
        }
        saltar.onClick.AddListener(() => SkipToLastSecond());
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("El video ha terminado.");
        // Llama a la función que deseas ejecutar cuando el video termine
        LoadSceneByName(scene);
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SkipToLastSecond()
    {
        if (videoPlayer.isPrepared)
        {
            double videoLength = videoPlayer.length;
            videoPlayer.time = videoLength;// Saltar al último segundo
            videoPlayer.Play();
        }
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoEnd;
        }
    }
}
