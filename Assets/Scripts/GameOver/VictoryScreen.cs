using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
    public GameObject victoryPanel; // Panel de Victoria dentro del Canvas

    public void MostrarVictoria()
    {
        victoryPanel.SetActive(true);
        Time.timeScale = 0f; // Pausar el juego
    }
}
