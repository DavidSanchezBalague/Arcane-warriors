using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoScreen; // Raw Image donde se ver� el video

    void Update()
    {
        // Si el video est� activo y presionas Esc o Espacio, se cierra
        if (videoScreen.activeSelf && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space)))
        {
            CloseVideo();
        }
    }

    public void PlayVideo()
    {
        videoScreen.SetActive(true);
        videoPlayer.Play();
    }

    public void CloseVideo()
    {
        videoPlayer.Stop();
        videoScreen.SetActive(false);
    }
}
