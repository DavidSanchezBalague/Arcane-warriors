using UnityEngine;

public class EnemigoMovimiento : MonoBehaviour
{
    public float velocidad = 3f; // Velocidad de movimiento del enemigo
    private Transform objetivo; // Referencia al jugador
    public float distanciaMinima = 1.5f; // Distancia mínima entre enemigos

    void Start()
    {
        // Intentar encontrar al jugador en la escena
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");

        if (jugador != null)
        {
            objetivo = jugador.transform; // Asignar la referencia del jugador si se encuentra
        }
        else
        {
            Debug.Log("No se ha encontrado un jugador con la etiqueta 'Player'. Asegúrate de que el jugador tiene esta etiqueta.");
        }
    }

    void Update()
    {
        if (objetivo == null) return; // Si no se ha encontrado el jugador, no hacer nada

        // Mover hacia el jugador
        Vector3 direccion = (objetivo.position - transform.position).normalized;

        // Detectar si hay otro enemigo muy cerca
        Collider2D[] colisiones = Physics2D.OverlapCircleAll(transform.position, distanciaMinima);
        foreach (Collider2D colision in colisiones)
        {
            if (colision.gameObject != gameObject && colision.CompareTag("Enemigo"))
            {
                // Si hay otro enemigo cerca, ajustar la dirección para evitarlo
                Vector3 evitar = (transform.position - colision.transform.position).normalized;
                direccion += evitar;
            }
        }

        // Normalizar dirección para mantener velocidad constante
        direccion = direccion.normalized;

        // Aplicar movimiento
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        // Si el enemigo toca al jugador, restarle vida
        if (colision.gameObject.CompareTag("Player"))
        {
            VidaPersonaje vida = colision.gameObject.GetComponent<VidaPersonaje>();
            if (vida != null)
            {
                vida.RestarVida(10); // Restar 10 puntos de vida (puedes ajustar este valor)
            }
        }
    }
}
