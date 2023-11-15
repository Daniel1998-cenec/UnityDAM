using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
    public ParticleSystem explosion;
    public ParticleSystem polvareda;

    public AudioClip sonidoSalto;
    public AudioClip sonidoChoque;
    private AudioSource sonidoJugador;

    void Start()
    {
        rbJugador = GetComponent<Rigidbody>();
        Physics.gravity *= modificadorGravedad;
        animacionJugador = GetComponent<Animator>();
        sonidoJugador = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estarSuelo && !gameOver)
        {
            rbJugador.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            estarSuelo = false;
            animacionJugador.SetTrigger("Jump_trig"); //podemos verlo en animator esto hace que al saltar use otra animación
            polvareda.Stop();
            sonidoJugador.PlayOneShot(sonidoSalto, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            estarSuelo = true;
            polvareda.Play();
        }
        else if (collision.gameObject.CompareTag("Obstaculo"))
        {
            Debug.Log("GAME OVER");
            gameOver = true;
            animacionJugador.SetBool("Death_b", true);
            animacionJugador.SetInteger("DeathType_int", 1);
            explosion.Play();
            polvareda.Stop();
            sonidoJugador.PlayOneShot(sonidoChoque, 1.0f);
        }
    }
}



