using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlotacionVisual : MonoBehaviour
{
    public float altura = 0.1f;        // Cu�nto sube y baja
    public float velocidad = 2f;       // Qu� tan r�pido se mueve

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.localPosition;
    }

    void Update()
    {
        float nuevaAltura = Mathf.Sin(Time.time * velocidad) * altura;
        transform.localPosition = posicionInicial + new Vector3(0f, nuevaAltura, 0f);
    }
}
