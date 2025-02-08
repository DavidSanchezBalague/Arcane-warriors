using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public void Start()
    {
        MusicManager.Instance.PlayMusic("MainMenu");
    }
    public void Play()
    {
        SceneManager.LoadScene("Game");
        MusicManager.Instance.PlayMusic("Game");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
