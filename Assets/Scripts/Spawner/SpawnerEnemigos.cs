using UnityEngine;

public class SpawnerEnemigos : MonoBehaviour
{
    public GameObject[] prefabsEnemigos; // Array de prefabs de enemigos
    public int cantidadInicial = 5; // Cantidad inicial de enemigos
    public float spawnRate = 2f; // Tiempo entre spawns (en segundos)
    public Rect limitesSpawn; // Rectángulo de los límites de spawn
    public int maxEnemigos = 20; // Máximo número de enemigos permitidos

    private int enemigosActuales = 0; // Contador de enemigos generados
    private ControladorEnemigos controladorEnemigos; // Referencia al controlador

    void Start()
    {
        controladorEnemigos = FindObjectOfType<ControladorEnemigos>(); // Buscar el controlador en la escena

        if (prefabsEnemigos == null || prefabsEnemigos.Length == 0)
        {
            Debug.LogError("¡No hay prefabs de enemigos asignados!");
            return;
        }



        Debug.Log("Se han asignado " + prefabsEnemigos.Length + " prefabs de enemigos.");

        for (int i = 0; i < cantidadInicial; i++)
        {
            SpawnEnemigo();
        }

        InvokeRepeating(nameof(SpawnEnemigo), spawnRate, spawnRate);
    }

    void SpawnEnemigo()
    {
        if (enemigosActuales >= maxEnemigos)
        {
            Debug.Log("Se ha alcanzado el límite de enemigos, deteniendo el spawn.");
            CancelInvoke(nameof(SpawnEnemigo));
            return;
        }

        if (prefabsEnemigos == null || prefabsEnemigos.Length == 0)
        {
            Debug.LogError("No hay prefabs de enemigos disponibles. Cancela el spawn.");
            CancelInvoke(nameof(SpawnEnemigo));
            return;
        }

        GameObject prefabElegido = prefabsEnemigos[Random.Range(0, prefabsEnemigos.Length)];
        float x = Random.Range(limitesSpawn.xMin, limitesSpawn.xMax);
        float y = Random.Range(limitesSpawn.yMin, limitesSpawn.yMax);
        Vector3 posicionSpawn = new Vector3(x, y, 0f);

        // ?? Instanciar el enemigo y guardar la referencia
        GameObject nuevoEnemigo = Instantiate(prefabElegido, posicionSpawn, Quaternion.identity);
        enemigosActuales++; // Incrementar el contador

        // ?? Notificar al controlador que se ha generado un enemigo
        if (controladorEnemigos != null)
        {
            controladorEnemigos.EnemigoGenerado();
        }

        Debug.Log("Enemigo generado (" + prefabElegido.name + ") en posición: " + posicionSpawn);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(limitesSpawn.center, new Vector3(limitesSpawn.width, limitesSpawn.height, 1f));
    }
}
