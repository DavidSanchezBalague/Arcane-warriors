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
        Debug.Log("Nivel desbloqueado antes de actualizar: " + nivelDesbloqueado);

        if (nivelActual >= nivelDesbloqueado) // Si es el último nivel desbloqueado
        {
            PlayerPrefs.SetInt("NivelDesbloqueado", nivelActual + 1);
            PlayerPrefs.Save();
            Debug.Log("Nuevo nivel desbloqueado: " + (nivelActual + 1));
        }
    }

}
