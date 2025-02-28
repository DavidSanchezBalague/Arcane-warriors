using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    public GameObject victoryPanel; // Panel de Victoria dentro del Canvas
    public int nivelActual;

    public void MostrarVictoria()
    {
        victoryPanel.SetActive(true);
        Time.timeScale = 0f; // Pausar el juego
        NivelCompletado();
    }
    void NivelCompletado()
    {
        int nivelDesbloqueado = PlayerPrefs.GetInt("NivelDesbloqueado", 1);

        // Si el nivel actual es el más alto desbloqueado, desbloquear el siguiente nivel
        if (nivelActual >= nivelDesbloqueado)
        {
            PlayerPrefs.SetInt("NivelDesbloqueado", nivelActual + 1);
            PlayerPrefs.Save();
        }
    }

}
