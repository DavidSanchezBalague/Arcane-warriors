using UnityEngine;

public class SpawnerEnemigos : MonoBehaviour
{
    public GameObject prefabEnemigo; // Prefab del enemigo
    public int cantidadInicial = 5; // Cantidad inicial de enemigos
    public float spawnRate = 2f; // Tiempo entre spawns (en segundos)
    public Rect limitesSpawn; // Rectángulo de los límites de spawn

    void Start()
    {
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
        // Generar una posición aleatoria dentro de los límites
        float x = Random.Range(limitesSpawn.xMin, limitesSpawn.xMax);
        float y = Random.Range(limitesSpawn.yMin, limitesSpawn.yMax);

        // Crear el enemigo en la posición aleatoria
        Vector3 posicionSpawn = new Vector3(x, y, 0f);
        Instantiate(prefabEnemigo, posicionSpawn, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        // Visualizar los límites de spawn en el editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(limitesSpawn.center, new Vector3(limitesSpawn.width, limitesSpawn.height, 1f));
    }
}
