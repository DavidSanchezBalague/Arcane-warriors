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
        // Buscar automáticamente el Slider si no está asignado
        if (sliderVidas == null)
        {
            GameObject sliderGO = GameObject.Find("SliderVidas");
            if (sliderGO != null)
                sliderVidas = sliderGO.GetComponent<Slider>();
        }

        // Buscar automáticamente el Text si no está asignado
        if (vidaText == null)
        {
            GameObject textoGO = GameObject.Find("VidaText");
            if (textoGO != null)
                vidaText = textoGO.GetComponent<TextMeshProUGUI>();
        }

        vidaJugador = FindObjectOfType<VidaPersonaje>();

        if (vidaJugador != null && sliderVidas != null)
        {
            sliderVidas.maxValue = vidaJugador.vidaMaxima;
            sliderVidas.value = vidaJugador.vidaActual;
            ActualizarTextoVida();
        }
        else
        {
            Debug.LogWarning("Faltan referencias: VidaPersonaje, Slider o Texto.");
        }
    }

    void Update()
    {
        if (vidaJugador != null && sliderVidas != null)
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
