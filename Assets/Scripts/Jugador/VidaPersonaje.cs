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

    private void Morir()
    {
        SoundManager.Instance.PlaySound3D("hurtPlayer", transform.position);
        Debug.Log("¡El jugador ha muerto!");

        // Ejemplo: desactivar el jugador (puedes cambiar esto por otras acciones, como reiniciar nivel, animación de muerte, etc.)
        gameObject.SetActive(false);
        if (backUpCamera != null)
        {
            backUpCamera.SetActive(true); // Activar la cámara de respaldo
        }

        if (playerCamera != null)
        {
            playerCamera.gameObject.SetActive(false); // Desactivar la cámara del jugador
        }
    }
}
