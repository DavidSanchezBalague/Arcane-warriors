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
        // Buscar autom�ticamente el Slider si no est� asignado
        if (sliderVidas == null)
        {
            GameObject sliderGO = GameObject.Find("SliderVidas");
            if (sliderGO != null)
                sliderVidas = sliderGO.GetComponent<Slider>();
        }

        // Buscar autom�ticamente el Text si no est� asignado
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

    // M�todo que actualiza el texto de la vida en la UI
    void ActualizarTextoVida()
    {
        if (vidaJugador != null)
        {
            vidaText.text = "Vida: " + vidaJugador.vidaActual;
        }
    }

    // M�todo para curar la vida del jugador
    public void CurarVida(int cantidad)
    {
        if (vidaJugador != null)
        {
            vidaJugador.CurarVida(cantidad); // Llama al m�todo de VidaPersonaje para curar
        }
    }

    // M�todo para recibir da�o
    public void RestarVida(int cantidad)
    {
        if (vidaJugador != null)
        {
            vidaJugador.RestarVida(cantidad); // Llama al m�todo de VidaPersonaje para restar vida
        }
    }

    // M�todo adicional para manejar el da�o (si se requiere en otras clases)
    public void TakeDamage(int damage)
    {
        if (vidaJugador != null)
        {
            vidaJugador.RestarVida(damage); // Llama al m�todo de VidaPersonaje para restar vida
        }
    }
}
