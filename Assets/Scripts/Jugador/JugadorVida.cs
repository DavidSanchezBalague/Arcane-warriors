using UnityEngine;
using TMPro; // Necesario si usas TextMeshPro
using UnityEngine.UI;

public class JugadorVida : MonoBehaviour
{
    [SerializeField] Slider sliderVidas;
    public TextMeshProUGUI vidaText; // Referencia al TextMeshPro del Canvas
    private VidaPersonaje vidaJugador; // Referencia al script VidaPersonaje

    void Start()
    {
        vidaJugador = FindObjectOfType<VidaPersonaje>(); // Encuentra el componente VidaPersonaje

        if (vidaJugador != null)
        {
            sliderVidas.maxValue = vidaJugador.vidaMaxima; // Establece el máximo de la barra
            sliderVidas.value = vidaJugador.vidaActual; // Establece el valor inicial de la barra
            ActualizarTextoVida(); // Actualiza el texto al inicio
        }
        else
        {
            Debug.LogError("No se encontró el componente VidaPersonaje.");
        }
    }

    void Update()
    {
        // Sincroniza constantemente la barra de vida con la vida actual del personaje
        if (vidaJugador != null)
        {
            sliderVidas.value = vidaJugador.vidaActual;
            ActualizarTextoVida();
        }
    }

    // Método que actualiza el texto de la vida en la UI
    void ActualizarTextoVida()
    {
        if (vidaJugador != null)
        {
            vidaText.text = "Vida: " + vidaJugador.vidaActual;
        }
    }

    // Método para curar la vida del jugador
    public void CurarVida(int cantidad)
    {
        if (vidaJugador != null)
        {
            vidaJugador.CurarVida(cantidad); // Llama al método de VidaPersonaje para curar
        }
    }

    // Método para recibir daño
    public void RestarVida(int cantidad)
    {
        if (vidaJugador != null)
        {
            vidaJugador.RestarVida(cantidad); // Llama al método de VidaPersonaje para restar vida
        }
    }

    // Método adicional para manejar el daño (si se requiere en otras clases)
    public void TakeDamage(int damage)
    {
        if (vidaJugador != null)
        {
            vidaJugador.RestarVida(damage); // Llama al método de VidaPersonaje para restar vida
        }
    }
}
