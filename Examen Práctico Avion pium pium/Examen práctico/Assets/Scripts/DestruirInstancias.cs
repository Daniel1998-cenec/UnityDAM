using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirInstancias : MonoBehaviour
{
    // Start is called before the first frame update
    float limiteSuperior = 25;
    float LimiteInferior = -30;
    ControlJuego controlJuego;

    void Start()

    {
        controlJuego = GameObject.Find("Generador").GetComponent<ControlJuego>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > limiteSuperior)
        {
            Destroy(gameObject);
            Debug.Log("estas jugando "+transform.position.z);
        } 
            else if(transform.position.z < LimiteInferior)
        {
            Destroy(gameObject);
            Debug.Log("El juego ha terminado "+transform.position.z);
            controlJuego.textoGameOver.gameObject.SetActive(true);
            controlJuego.botonReinicio.gameObject.SetActive(true);
            controlJuego.estarVivo = false;
        }

    }




}
