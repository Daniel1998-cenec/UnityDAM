using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivos : MonoBehaviour
{
     // Start is called before the first frame update
    private Rigidbody rbObjetivo; //creamos una variable rigidboy
    private ControlJuego controlJuego;
    public int valorPuntos;

    private float rangoX = 4.0F;
    private float posY = -1.0f;
    private float minVelocidad = 12.0F;
    private float maxVelocidad = 16.0f;
    private float fuerzaTorsion = 10.0f;
    

    void Start()
    {
        rbObjetivo = GetComponent<Rigidbody>();
        transform.position = posGeneracion();


        rbObjetivo.AddForce(FuerzaImpulso(), ForceMode.Impulse);
        //añadimos fuerza de giro
        rbObjetivo.AddTorque(ValorTorsion(), ValorTorsion(),
        ValorTorsion(), ForceMode.Impulse);

        controlJuego = GameObject.Find("Gestor de Juegos").GetComponent<ControlJuego>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown(){
        if (controlJuego.juegoEstaActivo) { //controlamos que si el juego no está activo, no se actualice el marcador

            Destroy(gameObject);
            controlJuego.ActualizarMarcador(valorPuntos);
        }

    }

    private void OnTriggerEnter(Collider other){

    Destroy(gameObject);
    controlJuego.GameOver();
    }

    Vector3 posGeneracion() { 
        return new Vector3(Random.Range(-rangoX, rangoX), posY);
    }


    Vector3 FuerzaImpulso() {
        return Vector3.up * Random.Range(minVelocidad, maxVelocidad);
    }
    float ValorTorsion() {
        return Random.Range(-fuerzaTorsion, fuerzaTorsion);
    }

}


