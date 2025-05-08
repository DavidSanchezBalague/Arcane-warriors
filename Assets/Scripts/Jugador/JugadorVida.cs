using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JugadorVida : MonoBehaviour
{
    [SerializeField] private Slider sliderVidas;
    public TextMeshProUGUI vidaText;
    private VidaPersonaje vidaJugador;

    [SerializeField] private GameObject gameOverPanel; // ? Correcto


    void Start()
    {
        if (sliderVidas == null)
        {
            GameObject sliderGO = GameObject.Find("Slider");
            if (sliderGO != null)
                sliderVidas = sliderGO.GetComponent<Slider>();
            else
                Debug.LogWarning("No se encontró el Slider en la escena.");
        }

        if (vidaText == null)
        {
            GameObject textoGO = GameObject.Find("VidaText");
            if (textoGO != null)
                vidaText = textoGO.GetComponent<TextMeshProUGUI>();
            else
                Debug.LogWarning("No se encontró VidaText en la escena.");
        }

        vidaJugador = FindObjectOfType<VidaPersonaje>();

        // Oculta el panel de Game Over al iniciar
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (vidaJugador == null) return;

        if (sliderVidas != null)
            sliderVidas.value = vidaJugador.vidaActual;

        ActualizarTextoVida();

        // Verifica si el jugador está muerto
        if (!vidaJugador.estaVivo && gameOverPanel != null && !gameOverPanel.activeSelf)
        {
            gameOverPanel.SetActive(true);
        }


    }

    void ActualizarTextoVida()
    {
        if (vidaJugador != null && vidaText != null)
        {
            vidaText.text = "Vida: " + vidaJugador.vidaActual;
        }
    }

    public void CurarVida(int cantidad)
    {
        if (vidaJugador != null)
        {
            vidaJugador.CurarVida(cantidad);
        }
    }

    public void RestarVida(int cantidad)
    {
        if (vidaJugador != null)
        {
            vidaJugador.RestarVida(cantidad);
        }
    }

    public void TakeDamage(int damage)
    {
        if (vidaJugador != null)
        {
            vidaJugador.RestarVida(damage);
        }
    }

    public void AsignarVida(VidaPersonaje personaje)
    {
        vidaJugador = personaje;

        if (sliderVidas != null)
        {
            sliderVidas.maxValue = vidaJugador.vidaMaxima;
            sliderVidas.value = vidaJugador.vidaActual;
        }

        ActualizarTextoVida();
    }
}
