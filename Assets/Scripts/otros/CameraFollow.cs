using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El personaje que la c�mara seguir�.
    public float smoothSpeed = 0.125f; // Velocidad de suavizado del movimiento de la c�mara.
    public Vector3 offset; // Desplazamiento opcional para ajustar la posici�n de la c�mara.

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcula la posici�n deseada.
            Vector3 desiredPosition = target.position + offset;
            // Suaviza la transici�n de la c�mara hacia la posici�n deseada.
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
