using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparitos : MonoBehaviour
{
    public int damage = 10; // Daño que causa la bala

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si la bala golpea al jugador
        if (collision.CompareTag("Player"))
        {
            JugadorVida player = collision.GetComponent<JugadorVida>();
            if (player != null)
            {
                player.RestarVida(damage); // Restar vida al jugador
            }

            // Destruir la bala después de impactar
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        // Destruir la bala si sale de la pantalla
        Destroy(gameObject);
    }
}
