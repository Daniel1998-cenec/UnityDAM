using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    private Rigidbody rbJugador;
    public float fuerzaSalto = 10;
    [SerializeField]
    private float modificadorGravedad = 2;
    public bool estarSuelo = true; // Corregido aquí: debes especificar el tipo de variable (bool) y usar el operador de asignación (=) en lugar de dos puntos (:).
    public bool gameOver;
    private Animator animacionJugador;

    void Start()
    {
        rbJugador = GetComponent<Rigidbody>();
        Physics.gravity *= modificadorGravedad;
        animacionJugador = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estarSuelo)
        {
            rbJugador.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            estarSuelo = false;
            animacionJugador.SetTrigger("Jump_trig"); //podemos verlo en animator esto hace que al saltar use otra animación

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            estarSuelo = true;
        }
        else if (collision.gameObject.CompareTag("Obstaculo"))
        {
            Debug.Log("GAME OVER");
            gameOver = true;
        }
    }
}



