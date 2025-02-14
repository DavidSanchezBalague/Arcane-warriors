using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad de movimiento
    public float margenLimite = 0.1f; // Margen que permite el movimiento cerca del l�mite

    // Limites del cuadrado con una escala de 25x10 centrado en (0,0)
    private Rect limites = new Rect(-95.5f, -30f, 230f, 80f);

    private void Update()
    {
        // Obtener la entrada del jugador para mover al personaje
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Movimiento del personaje
        Vector3 movimiento = new Vector3(horizontal, vertical, 0f) * velocidad * Time.deltaTime;

        // Verificar si el movimiento est� cerca del l�mite para evitar que se detenga abruptamente
        if (transform.position.x + movimiento.x < limites.xMin + margenLimite || transform.position.x + movimiento.x > limites.xMax - margenLimite)
        {
            movimiento.x = 0f; // Detener el movimiento en el eje X si est� cerca del l�mite
        }

        if (transform.position.y + movimiento.y < limites.yMin + margenLimite || transform.position.y + movimiento.y > limites.yMax - margenLimite)
        {
            movimiento.y = 0f; // Detener el movimiento en el eje Y si est� cerca del l�mite
        }

        // Aplicar movimiento
        transform.Translate(movimiento);

        // Limitar la posici�n del personaje dentro de los l�mites del cuadrado
        float clampedX = Mathf.Clamp(transform.position.x, limites.xMin, limites.xMax);
        float clampedY = Mathf.Clamp(transform.position.y, limites.yMin, limites.yMax);

        // Actualizar la posici�n del personaje con los valores limitados
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
