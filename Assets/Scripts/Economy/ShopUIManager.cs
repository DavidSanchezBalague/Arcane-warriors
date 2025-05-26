using UnityEngine;

public class ShopUIManager : MonoBehaviour
{
    public GameObject tiendaUI;
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
            }
        }
        else
        {
            Debug.Log("No tienes suficientes monedas.");
        }
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
