using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
    public GameObject bloqueoVelocidad;
    public GameObject bloqueoCurar;
    public GameObject bloqueoEspecial;
    public GameObject tiendaUI;
    public Button botonVelocidad;
    public Button botonCurar;
    public Button botonEspecial;
    private bool tiendaAbierta = false;

    public enum ShopItem
    {
        SubirVelocidad,
        CurarVida,
        HabilidadEspecial
    }

    private VidaPersonaje vidaJugador;
    private JugadorVida jugadorVidaUI;

    void Start()
    {
        vidaJugador = FindObjectOfType<VidaPersonaje>();
        jugadorVidaUI = FindObjectOfType<JugadorVida>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            tiendaAbierta = !tiendaAbierta;
            tiendaUI.SetActive(tiendaAbierta);

            if (tiendaAbierta)
            {
                StartCoroutine(EsperarYActualizarBloqueos());
            }

            Time.timeScale = tiendaAbierta ? 0 : 1;
        }
    }

    public void cerrar()
    {
        tiendaAbierta = false;
        tiendaUI.SetActive(false);
        Time.timeScale = 1;

        ControladorEnemigos controlador = FindObjectOfType<ControladorEnemigos>();
        if (controlador != null)
        {
            controlador.TiendaCerrada();
        }
    }
    private System.Collections.IEnumerator EsperarYActualizarBloqueos()
    {
        yield return null; // espera 1 frame
        ActualizarBloqueos();
    }
    public void ComprarSubirVelocidad()
    {
        ComprarItem(ShopItem.SubirVelocidad, 1);
    }

    public void ComprarCurarVida()
    {
        ComprarItem(ShopItem.CurarVida, 3);
    }

    // ?? NUEVO: único botón para habilidad especial
    public void ComprarHabilidadEspecial()
    {
        ComprarItem(ShopItem.HabilidadEspecial, 2); // Ajusta el precio si quieres
    }

    private void ComprarItem(ShopItem item, int precio)
    {
        if (EconomyManager.Instance.GastarMonedas(precio))
        {
            AplicarEfecto(item);

            if (EconomyManager.Instance.uiEconomia != null)
            {
                EconomyManager.Instance.uiEconomia.ActualizarMonedas(EconomyManager.Instance.ObtenerMonedas());
                ActualizarBloqueos();
            }
        }
        else
        {
            Debug.Log("No tienes suficientes monedas.");
        }
    }

    private void ActualizarBloqueos()
    {
        int monedas = EconomyManager.Instance.ObtenerMonedas();

        bool puedeVelocidad = monedas >= 1;
        bool puedeCurar = monedas >= 3;
        bool puedeEspecial = monedas >= 5;

        bloqueoVelocidad.SetActive(!puedeVelocidad);
        bloqueoCurar.SetActive(!puedeCurar);
        bloqueoEspecial.SetActive(!puedeEspecial);

        botonVelocidad.interactable = puedeVelocidad;
        botonCurar.interactable = puedeCurar;
        botonEspecial.interactable = puedeEspecial;
    }

    private void AplicarEfecto(ShopItem item)
    {
        Walk jugador = FindObjectOfType<Walk>();

        if (vidaJugador == null)
            vidaJugador = FindObjectOfType<VidaPersonaje>();

        if (jugadorVidaUI == null)
            jugadorVidaUI = FindObjectOfType<JugadorVida>();

        switch (item)
        {
            case ShopItem.SubirVelocidad:
                if (jugador != null)
                {
                    jugador.moveSpeed += 20f;
                    Debug.Log("Velocidad aumentada. Nueva velocidad: " + jugador.moveSpeed);
                }
                break;

            case ShopItem.CurarVida:
                if (vidaJugador != null && jugadorVidaUI != null)
                {
                    int cantidadCurar = 20;
                    jugadorVidaUI.CurarVida(cantidadCurar);
                    Debug.Log("Vida curada. Nueva vida: " + vidaJugador.vidaActual);
                }
                break;

            case ShopItem.HabilidadEspecial:
                GunController gun = FindObjectOfType<GunController>();
                if (gun != null)
                {
                    int personaje = PlayerPrefs.GetInt("PersonajeElegido");

                    switch (personaje)
                    {
                        case 0: // Gladiador
                            gun.ActivarLanzaExplosiva();
                            Debug.Log("Lanza explosiva activada para Gladiador.");
                            Debug.Log("PersonajeElegido (PlayerPrefs): " + personaje);

                            break;

                        case 1: // Ninja
                            gun.ActivarTripleDisparo();
                            Debug.Log("Triple disparo activado para Ninja.");
                            Debug.Log("PersonajeElegido (PlayerPrefs): " + personaje);

                            break;
                    }
                }
                break;
        }
    }
}
