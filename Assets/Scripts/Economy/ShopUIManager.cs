using UnityEngine;

public class ShopUIManager : MonoBehaviour
{
    public GameObject tiendaUI;
    private bool tiendaAbierta = false;

    public enum ShopItem
    {
        SubirVelocidad,
        CurarVida, // A?adido el ?tem de curar vida
        // m?s ?tems despu?s
    }

    private VidaPersonaje vidaJugador; // Referencia a VidaPersonaje
    private JugadorVida jugadorVidaUI; // Referencia a JugadorVida (para actualizar la UI)

    void Start()
    {
        vidaJugador = FindObjectOfType<VidaPersonaje>(); // Encuentra el componente VidaPersonaje
        jugadorVidaUI = FindObjectOfType<JugadorVida>(); // Encuentra el componente JugadorVida
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("?T presionada!");
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


    // Funci?n p?blica para el bot?n "Subir Velocidad"
    public void ComprarSubirVelocidad()
    {
        ComprarItem(ShopItem.SubirVelocidad, 1); // Puedes cambiar el precio
    }

    // Funci?n p?blica para el bot?n "Curar Vida"
    public void ComprarCurarVida()
    {
        ComprarItem(ShopItem.CurarVida, 3); // Precio para curar vida, ajusta seg?n lo que necesites
    }

    private void ComprarItem(ShopItem item, int precio)
    {
        if (EconomyManager.Instance.GastarMonedas(precio))
        {
            // Aplicar el efecto de la compra (como subir velocidad o curar vida)
            AplicarEfecto(item);

            // Actualizar la UI de las monedas despu?s de la compra
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
        Walk jugador = FindObjectOfType<Walk>(); // Si tienes movimiento, lo puedes usar

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
                Debug.Log("Intentando curar vida...");
                Debug.Log("vidaJugador: " + vidaJugador);
                Debug.Log("jugadorVidaUI: " + jugadorVidaUI);

                if (vidaJugador != null && jugadorVidaUI != null)
                {
                    int cantidadCurar = 20;
                    jugadorVidaUI.CurarVida(cantidadCurar);
                    Debug.Log("Vida curada. Nueva vida: " + vidaJugador.vidaActual);
                }
                break;

                // Aqu? puedes agregar m?s efectos luego
        }
    }

}