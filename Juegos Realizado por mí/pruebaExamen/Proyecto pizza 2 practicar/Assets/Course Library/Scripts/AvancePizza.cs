using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvancePizza : MonoBehaviour
{
    public float velocidad = 40f;
    ControlJuego controlJuego;

    // Start is called before the first frame update
    void Start()
    {
        controlJuego = GameObject.Find("Generador").GetComponent<ControlJuego>();   
    }

    // Update is called once per frame
    void Update()
    {
        

        if (controlJuego.estarVivo)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * velocidad);
        } 
    }
}
