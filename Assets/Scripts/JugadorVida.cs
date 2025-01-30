using UnityEngine;
using TMPro; // Necesario si usas TextMeshPro
using UnityEngine.UI;

public class JugadorVida : MonoBehaviour
{
    [SerializeField] Slider sliderVidas;
    public int vidaInicial = 100; // Vida inicial del jugador
    private int vidaActual; // Vida actual del jugador
    

    public TextMeshProUGUI vidaText; // Referencia al TextMeshPro del Canvas

    void Start()
    {
        vidaActual = vidaInicial; // Inicializa la vida actual
        sliderVidas.maxValue = vidaInicial;
        sliderVidas.value = sliderVidas.maxValue;
        ActualizarTextoVida(); // Actualiza la UI al inicio
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Detecta si el jugador colisiona con un enemigo
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            RestarVida(10); // Resta 10 de vida al jugador
        }
    }

    void RestarVida(int cantidad)
    {
        vidaActual -= cantidad; // Resta la cantidad de vida
        vidaActual = Mathf.Max(vidaActual, 0); // Asegura que la vida no sea negativa
        Debug.Log("Vida actual: " + vidaActual); // Muestra en la consola la vida actual

        sliderVidas.value = vidaActual;
        ActualizarTextoVida(); // Actualiza el texto de vida en pantalla

        // Si la vida llega a 0, puedes manejar la lógica de muerte aquí
        if (vidaActual <= 0)
        {
            Debug.Log("¡El jugador ha muerto!");
            // Aquí puedes implementar más lógica, como reiniciar el nivel
        }
    }

    void ActualizarTextoVida()
    {
        // Actualiza el texto de la UI con la vida actual
        vidaText.text = "Vida: " + vidaActual;
    }
}
