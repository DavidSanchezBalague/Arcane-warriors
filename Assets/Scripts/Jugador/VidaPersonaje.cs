using UnityEngine;

public class VidaPersonaje : MonoBehaviour
{
    public int vidaMaxima = 100; // Vida máxima del personaje
    public int vidaActual { get; private set; } // Vida actual del personaje (propiedad pública solo lectura)
    public bool estaVivo { get; private set; } = true; // Bandera de vida del jugador
    [SerializeField] private GameObject backUpCamera;
    [SerializeField] private Camera playerCamera;

    void Start()
    {
        // Inicializar la vida actual al máximo al inicio
        vidaActual = vidaMaxima;

        if (playerCamera != null)
        {
            playerCamera.gameObject.SetActive(true);
        }

        if (backUpCamera != null)
        {
            backUpCamera.SetActive(false);
        }
    }

    public void RestarVida(int cantidad)
    {
        if (!estaVivo) return; // Si el jugador ya está muerto, no restar más vida.

        SoundManager.Instance.PlaySound3D("hurtPlayer", transform.position);

        vidaActual -= cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);

        Debug.Log("Vida actual del jugador: " + vidaActual);

        if (vidaActual <= 0)
        {
            estaVivo = false; // Marcar al jugador como muerto
            Morir();
        }
    }

    public void CurarVida(int cantidad)
    {
        if (!estaVivo) return; // No curar si el jugador está muerto

        vidaActual += cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima); // Asegura que no se pase de la vida máxima

        Debug.Log("Vida curada. Nueva vida: " + vidaActual);
    }

    private void Morir()
    {
        SoundManager.Instance.PlaySound3D("hurtPlayer", transform.position);
        Debug.Log("¡El jugador ha muerto!");

        // Desactivar el jugador
        gameObject.SetActive(false);

        // Activar cámara de respaldo
        if (backUpCamera != null)
            backUpCamera.SetActive(true);

        if (playerCamera != null)
            playerCamera.gameObject.SetActive(false);

        // Mostrar Game Over
        GameOver gameOverManager = FindAnyObjectByType<GameOver>();
        if (gameOverManager != null)
        {
            gameOverManager.MostrarGameOver();
        }
        else
        {
            Debug.LogWarning("No se encontró el script GameOver en la escena.");
        }
    }

}
