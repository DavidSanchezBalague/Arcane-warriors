using UnityEngine;

public class SpawnerEnemigos : MonoBehaviour
{
    public GameObject prefabEnemigo; // Prefab del enemigo
    public int cantidadInicial = 5; // Cantidad inicial de enemigos
    public float spawnRate = 2f; // Tiempo entre spawns (en segundos)
    public Rect limitesSpawn; // Rect�ngulo de los l�mites de spawn

    void Start()
    {
        if (prefabEnemigo == null)
        {
            Debug.LogError("�No se ha asignado ning�n prefab al campo 'Prefab Enemigo'!");
        }
        else
        {
            Debug.Log("Prefab Enemigo asignado correctamente: " + prefabEnemigo.name);
        }

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
        // Validar si el prefab est� asignado y no es nulo
        if (prefabEnemigo == null)
        {
            Debug.LogError("El prefab de enemigo no est� asignado o fue destruido. Cancela el spawn.");
            CancelInvoke(nameof(SpawnEnemigo)); // Det�n la generaci�n peri�dica de enemigos
            return;
        }

        // Generar una posici�n aleatoria dentro de los l�mites
        float x = Random.Range(limitesSpawn.xMin, limitesSpawn.xMax);
        float y = Random.Range(limitesSpawn.yMin, limitesSpawn.yMax);

        Vector3 posicionSpawn = new Vector3(x, y, 0f);

        // Instanciar el enemigo
        Instantiate(prefabEnemigo, posicionSpawn, Quaternion.identity);

        Debug.Log("Enemigo generado en posici�n: " + posicionSpawn);
    }


    private void OnDrawGizmos()
    {
        // Visualizar los l�mites de spawn en el editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(limitesSpawn.center, new Vector3(limitesSpawn.width, limitesSpawn.height, 1f));
    }
}
