using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow1 : MonoBehaviour
{
    public float smoothSpeed = 5f;
    public Vector3 offset;

    private Transform target;

    // NUEVO: límites
    public Vector2 minLimits;
    public Vector2 maxLimits;

    private void LateUpdate()
    {
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                target = player.transform;
        }

        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;

            // Aplicar límites a la posición deseada
            float clampedX = Mathf.Clamp(desiredPosition.x, minLimits.x, maxLimits.x);
            float clampedY = Mathf.Clamp(desiredPosition.y, minLimits.y, maxLimits.y);
            Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

            // Movimiento suave
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
