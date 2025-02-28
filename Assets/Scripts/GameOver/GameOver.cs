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
        LevelManager.Instance.LoadScene("Game 2", "CrossFade");
    }
    public void Game3()
    {
        Time.timeScale = 1;
        ScoreManager.Instance.ResetScore();
        LevelManager.Instance.LoadScene("Game 3 real", "CrossFade");
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1;

        ScoreManager.Instance.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IralMenuPrincipal()
    {
        Time.timeScale = 1;
        ScoreManager.Instance.ResetScore();
        SceneManager.LoadScene("Menu");
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
