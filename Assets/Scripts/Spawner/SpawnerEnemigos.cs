using UnityEngine;

public class SpawnerEnemigos : MonoBehaviour
{
    public GameObject[] prefabsEnemigos; // Array de prefabs de enemigos
    public int cantidadInicial = 5; // Cantidad inicial de enemigos
    public float spawnRate = 2f; // Tiempo entre spawns (en segundos)
    public Rect limitesSpawn; // Rectángulo de los límites de spawn

    void Start()
    {
        // Verificar si hay prefabs asignados
        if (prefabsEnemigos == null || prefabsEnemigos.Length == 0)
        {
            Debug.LogError("¡No hay prefabs de enemigos asignados!");
            return;
        }

        Debug.Log("Se han asignado " + prefabsEnemigos.Length + " prefabs de enemigos.");

        // Spawn inicial de enemigos
        for (int i = 0; i < cantidadInicial; i++)
        {
            SpawnEnemigo();
        }

        // Comenzar a spawnear periódicamente
        InvokeRepeating(nameof(SpawnEnemigo), spawnRate, spawnRate);
    }

    void SpawnEnemigo()
    {
        // Verificar que haya prefabs disponibles
        if (prefabsEnemigos == null || prefabsEnemigos.Length == 0)
        {
            Debug.LogError("No hay prefabs de enemigos disponibles. Cancela el spawn.");
            CancelInvoke(nameof(SpawnEnemigo)); // Detener la invocación periódica
            return;
        }

        // Elegir un prefab de enemigo aleatorio
        GameObject prefabElegido = prefabsEnemigos[Random.Range(0, prefabsEnemigos.Length)];

        // Generar una posición aleatoria dentro de los límites
        float x = Random.Range(limitesSpawn.xMin, limitesSpawn.xMax);
        float y = Random.Range(limitesSpawn.yMin, limitesSpawn.yMax);
        Vector3 posicionSpawn = new Vector3(x, y, 0f);

        // Instanciar el enemigo
        Instantiate(prefabElegido, posicionSpawn, Quaternion.identity);

        Debug.Log("Enemigo generado (" + prefabElegido.name + ") en posición: " + posicionSpawn);
    }

    private void OnDrawGizmos()
    {
        // Visualizar los límites de spawn en el editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(limitesSpawn.center, new Vector3(limitesSpawn.width, limitesSpawn.height, 1f));
    }
}
