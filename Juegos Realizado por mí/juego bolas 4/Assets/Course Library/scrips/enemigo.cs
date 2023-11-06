using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rbEnemigo;
    private GameObject jugador;
    public float velocidad = 3;

    void Start()
    {

        rbEnemigo = GetComponent<Rigidbody>();
        jugador = GameObject.Find("Jugador");
    }

    // Update is called once per frame
    void Update()
    {
        //le decimos que el enemigo calcule la distancia entre la posición del jugador con la suya propia y se dirija hacia el.
        Vector3 vectorObjectivo= (jugador.transform.position - transform.position).normalized;
        rbEnemigo.AddForce(vectorObjectivo * velocidad);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }


    }
}
