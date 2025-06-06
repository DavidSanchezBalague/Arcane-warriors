using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text textPuntos;

    public GameObject gameOverPanel;

    public void MostrarGameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        textPuntos.text = (("Puntuacion: ") + FindAnyObjectByType<ScoreManager>().score).ToString();

    }

    public void Game2()
    {
        Time.timeScale = 1;
        ScoreManager.Instance.ResetScore();
        LevelManager.Instance.LoadSceneWithImage("Game2FINAL", "CrossFade", 1);
    }
    public void Game3()
    {
        Time.timeScale = 1;
        ScoreManager.Instance.ResetScore();
        LevelManager.Instance.LoadSceneWithImage("Game3FINAL", "CrossFade", 2);
    }
    public void Game4()
    {
        Time.timeScale = 1;
        ScoreManager.Instance.ResetScore();
        LevelManager.Instance.LoadSceneWithImage("Game4FINAL", "CrossFade", 3);
    }
    public void Game5()
    {
        Time.timeScale = 1;
        ScoreManager.Instance.ResetScore();
        LevelManager.Instance.LoadSceneWithImage("Game5FINAL", "CrossFade", 4);
    }
    public void Game6()
    {
        Time.timeScale = 1;
        ScoreManager.Instance.ResetScore();
        LevelManager.Instance.LoadSceneWithImage("Game6FINAL", "CrossFade", 5);
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1;

        ScoreManager.Instance.ResetScore();
        EconomyManager.Instance.ReiniciarMonedas();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IralMenuPrincipal()
    {
        Time.timeScale = 1;
        ScoreManager.Instance.ResetScore();
        EconomyManager.Instance.ReiniciarMonedas();
        SceneManager.LoadScene("Menu");
    }

    public void IrAPantallaFinal()
    {
        Time.timeScale = 1;

        int puntuacionFinal = LevelManager.Instance.puntuacionTotal; // ✅ puntos acumulados


        Debug.Log("Puntuación acumulada: " + puntuacionFinal); // ✅ AHORA sí, antes de guardar

        PlayerPrefs.SetInt("PuntuacionFinal", puntuacionFinal);
        PlayerPrefs.Save();

        SceneManager.LoadScene("FinalScoreScene");
    }



    void NivelCompletado(int nivelActual)
    {
        int nivelDesbloqueado = PlayerPrefs.GetInt("NivelDesbloqueado", 1);

        // Si el jugador completó un nivel por primera vez, desbloquear el siguiente
        if (nivelActual >= nivelDesbloqueado)
        {
            PlayerPrefs.SetInt("NivelDesbloqueado", nivelActual + 1);
            PlayerPrefs.Save();
        }

        // Volver al menú de niveles
        SceneManager.LoadScene("Menu Levels");
    }
}
