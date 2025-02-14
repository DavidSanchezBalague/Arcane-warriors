using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;  // Velocidad de movimiento del personaje
    public RectTransform limitArea;  // La imagen que act�a como l�mite (como RectTransform)

    private Vector3 velocity;

    void Update()
    {
        // Obtener la entrada del jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calcular la direcci�n del movimiento
        velocity = new Vector3(horizontal, vertical, 0f).normalized * speed * Time.deltaTime;

        // Mover el personaje
        transform.Translate(velocity);

        // Llamar a la funci�n para limitar el movimiento
        ClampPosition();
    }

    void ClampPosition()
    {
        // Obtener las esquinas de la imagen limitante en el espacio global
        Vector3 minBound = limitArea.TransformPoint(new Vector2(-limitArea.rect.width / 2, -limitArea.rect.height / 2));  // Esquina inferior izquierda
        Vector3 maxBound = limitArea.TransformPoint(new Vector2(limitArea.rect.width / 2, limitArea.rect.height / 2));  // Esquina superior derecha

        // Limitar la posici�n del personaje dentro de estos l�mites
        float clampedX = Mathf.Clamp(transform.position.x, minBound.x, maxBound.x);
        float clampedY = Mathf.Clamp(transform.position.y, minBound.y, maxBound.y);

        // Aplicar la posici�n limitada
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
