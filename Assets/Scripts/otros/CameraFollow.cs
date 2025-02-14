using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El personaje que la cámara seguirá.
    public float smoothSpeed = 0.125f; // Velocidad de suavizado del movimiento de la cámara.
    public Vector3 offset; // Desplazamiento opcional para ajustar la posición de la cámara.

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcula la posición deseada.
            Vector3 desiredPosition = target.position + offset;
            // Suaviza la transición de la cámara hacia la posición deseada.
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
