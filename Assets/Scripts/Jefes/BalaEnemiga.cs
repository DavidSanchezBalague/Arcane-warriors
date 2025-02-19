using UnityEngine;

public class BalaEnemiga : MonoBehaviour
{
    public int daño = 10; // Daño que inflige la bala
    public float velocidad = 5f; // Velocidad de la bala
    public float tiempoDeVida = 5f; // Tiempo antes de que la bala se destruya automáticamente

    private void Start()
    {
        Destroy(gameObject, tiempoDeVida); // Destruir la bala después de cierto tiempo
    }

    private void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime); // Mover la bala hacia adelante
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Asegurar que el jugador tiene el tag correcto
        {
            // Intentar restar vida usando ambos scripts de vida
            VidaPersonaje vidaPersonaje = collision.GetComponent<VidaPersonaje>();
            if (vidaPersonaje != null)
            {
                vidaPersonaje.RestarVida(daño);
            }

            JugadorVida jugadorVida = collision.GetComponent<JugadorVida>();
            if (jugadorVida != null)
            {
                jugadorVida.TakeDamage(daño);
            }

            // Destruir la bala después del impacto
            Destroy(gameObject);
        }
    }
}
