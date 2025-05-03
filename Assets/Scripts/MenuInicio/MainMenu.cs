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
        LevelManager.Instance.LoadScene("EleccionPersonaje", "");
        //MusicManager.Instance.PlayMusic("Game");
    }
    public void Game1()
    {
        LevelManager.Instance.LoadSceneWithImage("Game", "CrossFade", 0);
    }

    public void Game2()
    {
        LevelManager.Instance.LoadSceneWithImage("Game 2", "CrossFade", 1);
    }

    public void Game3()
    {
        LevelManager.Instance.LoadSceneWithImage("Game 3 Buena", "CrossFade", 2);
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
        if (musicSlider != null)
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f); // Valor por defecto

        if (sfxSlider != null)
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f); // Valor por defecto
    }

    public void ResetearProgreso()
    {
        PlayerPrefs.SetInt("NivelDesbloqueado", 1); // Asegura que empieza en 1
        PlayerPrefs.Save();
        Debug.Log("Progreso reiniciado: NivelDesbloqueado = 1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
