using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    public GameObject victoryPanel; // Panel de Victoria dentro del Canvas
    public TextMeshProUGUI textoPuntuacion;

    public void MostrarVictoria()
    {
        // Obtener la puntuación (esto depende de cómo la guardes)
        int puntos = FindObjectOfType<ScoreManager>().GetScore();
        LevelManager.Instance.AñadirPuntos(puntos);
        textoPuntuacion.text = "PUNTUACION: " + LevelManager.Instance.puntuacionTotal.ToString("00");


        victoryPanel.SetActive(true);
        Time.timeScale = 0f;
        NivelCompletado();
    }

    void NivelCompletado()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        int nivelReal = buildIndex - 2; // porque Menu, Elección y Menu Levels están antes

        int nivelDesbloqueado = PlayerPrefs.GetInt("NivelDesbloqueado", 1);

        Debug.Log("BuildIndex actual: " + buildIndex);
        Debug.Log("Nivel actual (real): " + nivelReal);
        Debug.Log("Nivel desbloqueado guardado antes: " + nivelDesbloqueado);

        int siguienteNivel = nivelReal + 1;

        if (siguienteNivel > nivelDesbloqueado)
        {
            PlayerPrefs.SetInt("NivelDesbloqueado", siguienteNivel);
            PlayerPrefs.Save();
            Debug.Log("Nuevo nivel desbloqueado: " + siguienteNivel);
        }
    }


}
