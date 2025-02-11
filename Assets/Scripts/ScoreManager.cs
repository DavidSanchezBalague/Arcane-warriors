using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score;

    private void Awake()
    {
        // Singleton para asegurarnos de que solo haya una instancia
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantener el objeto entre escenas
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        ResetScore(); // IMPORTANTE: Resetear la puntuación al inicio de la partida
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("Puntos: " + score);
    }

    public int GetScore()
    {
        return score;
    }
}
