using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirInstancia : MonoBehaviour
{
    float limiteSuperior = 30;
    float limiteInferior = -10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > limiteSuperior ||
           transform.position.z < limiteInferior)
        {
            Destroy(gameObject);
            Debug.Log("estas jugando");
        }
        else if (transform.position.z < limiteInferior)
        {
            Destroy(gameObject);
            Debug.Log("El juego ha terminado");
        }

    }
}
