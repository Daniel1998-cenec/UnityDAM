using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorColisiones : MonoBehaviour    
{
    public int valorPuntos;
    ControlJuego controljuego;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        controljuego.actualizarMarcador(valorPuntos);
        Console.WriteLine("ha impactado");

    }

}
