using UnityEngine;

public class VidaPersonaje : MonoBehaviour
{
    public int vidaMaxima = 100; // Vida m�xima del personaje
    public int vidaActual { get; private set; } // Vida actual del personaje (propiedad p�blica solo lectura)
    public bool estaVivo { get; private set; } = true; // Bandera de vida del jugador
    [SerializeField] private GameObject backUpCamera;
    [SerializeField] private Camera playerCamera;
    void Start()
    {
        // Inicializar la vida actual al m�ximo al inicio
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
        if (!estaVivo) return; // Si el jugador ya est� muerto, no restar m�s vida.

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
        Debug.Log("�El jugador ha muerto!");

        // Ejemplo: desactivar el jugador (puedes cambiar esto por otras acciones, como reiniciar nivel, animaci�n de muerte, etc.)
        gameObject.SetActive(false);
        if (backUpCamera != null)
        {
            backUpCamera.SetActive(true); // Activar la c�mara de respaldo
        }

        if (playerCamera != null)
        {
            playerCamera.gameObject.SetActive(false); // Desactivar la c�mara del jugador
        }
    }
}
