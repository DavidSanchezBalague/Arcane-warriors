using UnityEngine;

public class VidaPersonaje : MonoBehaviour
{
    public int vidaMaxima = 100; // Vida m�xima del personaje
    public int vidaActual { get; private set; } // Vida actual del personaje (propiedad p�blica solo lectura)
    public bool estaVivo { get; private set; } = true; // Bandera de vida del jugador

    void Start()
    {
        // Inicializar la vida actual al m�ximo al inicio
        vidaActual = vidaMaxima;
    }

    public void RestarVida(int cantidad)
    {
        if (!estaVivo) return; // Si el jugador ya est� muerto, no restar m�s vida.

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
        Debug.Log("�El jugador ha muerto!");

        // Ejemplo: desactivar el jugador (puedes cambiar esto por otras acciones, como reiniciar nivel, animaci�n de muerte, etc.)
        gameObject.SetActive(false);
    }
}
