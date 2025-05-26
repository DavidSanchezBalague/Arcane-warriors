using UnityEngine;

public class RotarProyectil : MonoBehaviour
{
    public float velocidadRotacion = 360f; // grados por segundo

   


    void Update()
    {
        transform.Rotate(0f, 0f, velocidadRotacion * Time.deltaTime);
    }
}
