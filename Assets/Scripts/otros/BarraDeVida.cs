using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con la UI

public class BarraDeVida : MonoBehaviour
{
    public Slider slider; // Referencia al Slider
    public VidaPersonaje vidaPersonaje; // Referencia al script de vida del jugador

    void Start()
    {
        // Inicializar el valor máximo del slider al inicio
        slider.maxValue = vidaPersonaje.vidaMaxima;
        slider.value = vidaPersonaje.vidaMaxima; // Establecer la vida inicial
    }

    void Update()
    {
        // Sincronizar el valor del slider con la vida actual del jugador
        slider.value = vidaPersonaje.vidaActual;
    }
}
