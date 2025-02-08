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

    public void ReiniciarNivel()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IralMenuPrincipal()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
