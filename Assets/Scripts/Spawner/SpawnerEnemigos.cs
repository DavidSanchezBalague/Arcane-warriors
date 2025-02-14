using UnityEngine;

public class SpawnerEnemigos : MonoBehaviour
{
    public GameObject[] prefabsEnemigos; // Array de prefabs de enemigos
    public int cantidadInicial = 5; // Cantidad inicial de enemigos
    public float spawnRate = 2f; // Tiempo entre spawns (en segundos)
    public Rect limitesSpawn; // Rect�ngulo de los l�mites de spawn

    void Start()
    {
        // Verificar si hay prefabs asignados
        if (prefabsEnemigos == null || prefabsEnemigos.Length == 0)
        {
            Debug.LogError("�No hay prefabs de enemigos asignados!");
            return;
        }

        Debug.Log("Se han asignado " + prefabsEnemigos.Length + " prefabs de enemigos.");

        // Spawn inicial de enemigos
        for (int i = 0; i < cantidadInicial; i++)
        {
            SpawnEnemigo();
        }

        // Comenzar a spawnear peri�dicamente
        InvokeRepeating(nameof(SpawnEnemigo), spawnRate, spawnRate);
    }

    void SpawnEnemigo()
    {
        // Verificar que haya prefabs disponibles
        if (prefabsEnemigos == null || prefabsEnemigos.Length == 0)
        {
            Debug.LogError("No hay prefabs de enemigos disponibles. Cancela el spawn.");
            CancelInvoke(nameof(SpawnEnemigo)); // Detener la invocaci�n peri�dica
            return;
        }

        // Elegir un prefab de enemigo aleatorio
        GameObject prefabElegido = prefabsEnemigos[Random.Range(0, prefabsEnemigos.Length)];

        // Generar una posici�n aleatoria dentro de los l�mites
        float x = Random.Range(limitesSpawn.xMin, limitesSpawn.xMax);
        float y = Random.Range(limitesSpawn.yMin, limitesSpawn.yMax);
        Vector3 posicionSpawn = new Vector3(x, y, 0f);

        // Instanciar el enemigo
        Instantiate(prefabElegido, posicionSpawn, Quaternion.identity);

        Debug.Log("Enemigo generado (" + prefabElegido.name + ") en posici�n: " + posicionSpawn);
    }

    private void OnDrawGizmos()
    {
        // Visualizar los l�mites de spawn en el editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(limitesSpawn.center, new Vector3(limitesSpawn.width, limitesSpawn.height, 1f));
    }
}
