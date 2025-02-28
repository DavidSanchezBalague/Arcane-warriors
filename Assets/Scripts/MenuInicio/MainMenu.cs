using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;

    public void Start()
    {
        MusicManager.Instance.PlayMusic("MainMenu");
        LoadVolume();
    }
    public void Play()
    {
        LevelManager.Instance.LoadScene("Menu Levels", "");
        //MusicManager.Instance.PlayMusic("Game");
    }
    public void Game1()
    {
        LevelManager.Instance.LoadScene("Game", "CrossFade");
    }
    public void Game2()
    {
        LevelManager.Instance.LoadScene("Game 2", "CrossFade");
    }
    public void Game3()
    {
        LevelManager.Instance.LoadScene("Game 3 real", "CrossFade");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void UpdateSoundVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }

    public void SaveVolume()
    {
        audioMixer.GetFloat("MusicVolume", out float musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);

        audioMixer.GetFloat("SFXVolume", out float sfxVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }

    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }
    public void ResetearProgreso()
    {
        PlayerPrefs.SetInt("NivelDesbloqueado", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
