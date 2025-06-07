using UnityEngine;

public class ControladorEnemigos : MonoBehaviour
{
    public SpawnerEnemigos spawner;
    public GameObject tiendaCanvas;
    public int enemigosOleada1 = 3;
    public int enemigosOleada2 = 3;
    public GameObject bossPrefab;

    private int enemigosRestantes;
    private int oleadaActual;
    private int totalOleadas = 2;

    private bool esperandoTienda;    // tienda por oleada
    private bool tiendaManual;       // tienda comprada mid‐round
    private bool bossGenerado;
    private bool primeraOleadaLanzada = false;

    void Start()
    {
        if (!primeraOleadaLanzada)
        {
            IniciarOleada();
            primeraOleadaLanzada = true;
        }
    }

    // Llamar desde tu botón “Abrir tienda” mid‐round
    public void MostrarTiendaManual()
    {
        tiendaManual = true;
        Time.timeScale = 0;
        ShopUIManager shop = FindObjectOfType<ShopUIManager>();
        if (shop != null)
        {
            shop.AbrirTienda();
        }
        else
        {
            Debug.LogWarning("No se encontró el ShopUIManager para abrir la tienda.");
        }
    }

    // Interno: cuando realmente acabas la oleada
    void MostrarTiendaPorOleada()
    {
        esperandoTienda = true;
        Time.timeScale = 0;
        ShopUIManager shop = FindObjectOfType<ShopUIManager>();
        if (shop != null)
        {
            shop.AbrirTienda();
        }
        else
        {
            Debug.LogWarning("No se encontró el ShopUIManager para abrir la tienda.");
        }
    }

    public void EnemigoGenerado()
    {
        enemigosRestantes++;
    }


    public void EnemigoEliminado()
    {
        if (bossGenerado) return;

        enemigosRestantes--;
        if (enemigosRestantes <= 0 && !esperandoTienda)
            MostrarTiendaPorOleada();
    }

    // Único método de cierre de tienda
    public void TiendaCerrada()
    {
        Time.timeScale = 1;
        tiendaCanvas.SetActive(false);

        // Si era la tienda que abriste tú manualmente, sólo la cierras
        if (tiendaManual)
        {
            tiendaManual = false;
            return;
        }

        // Si era la tienda de fin de oleada, arranca siguiente
        esperandoTienda = false;
        if (oleadaActual < totalOleadas)
            IniciarOleada();
        else
            GenerarBoss();
    }
    public bool EraTiendaPorOleada()
    {
        return esperandoTienda;
    }

    // Cierre de tienda manual (no avanza oleada ni genera boss)
    public void TiendaCerradaManual()
    {
        Time.timeScale = 1;
        tiendaCanvas.SetActive(false);
        tiendaManual = false;
        Debug.Log("Tienda cerrada manualmente, sin avanzar oleada.");
    }


    void IniciarOleada()
    {
        oleadaActual++;
        enemigosRestantes = 0;
        int n = (oleadaActual == 1) ? enemigosOleada1 : enemigosOleada2;
        spawner.SpawnOleada(n);
        Debug.Log($"Oleada {oleadaActual} con {n} enemigos");
    }

    void GenerarBoss()
    {
        if (bossGenerado || bossPrefab == null) return;
        Instantiate(bossPrefab, Vector3.zero, Quaternion.identity);
        bossGenerado = true;
        Debug.Log("¡Boss generado!");
    }
}
