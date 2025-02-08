using UnityEngine;
using TMPro;

public class PuntosInGame : MonoBehaviour
{
    public static PuntosInGame instance; // Singleton para acceder desde otros scripts
    public TextMeshProUGUI scoreText; // Referencia al texto en pantalla
    private int score = 0; // Puntuación inicial

    private void Awake()
    {
        // Asegurar que solo hay una instancia de ScoreManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        UpdateScoreUI(); // Mostrar la puntuación inicial
    }

    public void AddScore(int amount)
    {
        score += amount; // Sumar puntos
        UpdateScoreUI(); // Actualizar en pantalla
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Puntos: " + score; // Cambia el texto
        }
    }
}
