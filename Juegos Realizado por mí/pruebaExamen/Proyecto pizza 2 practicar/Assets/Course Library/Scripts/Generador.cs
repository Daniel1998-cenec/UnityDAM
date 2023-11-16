using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject[] animalesPrefab;
    private float xposicion1 = 20f;
    private float xposicion2 = 20f;

    private float inicioGeneracion = 2.0f;
    private float retardoGeneracion = 1.5f;
    
    ControlJuego controlJuego;

    void Start()
    {
        controlJuego = GameObject.Find("Generador").GetComponent<ControlJuego>();
        InvokeRepeating("GenerarAleatorio", inicioGeneracion, retardoGeneracion);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P) && controlJuego.estarVivo)
        {
            int a = Random.Range(0, animalesPrefab.Length);
            int x = Random.Range(-20, 21);
            // creando una instancia de Vector3
            //Vector3 PosicionGenerator = new(Random.Range(-xposicion1, xposicion2), 0, 20);

            Instantiate(animalesPrefab[a], new Vector3(x, 0, 20), animalesPrefab[a].transform.rotation);
        } 
        
    }

    void GenerarAleatorio()
    {
        
        if (controlJuego.estarVivo)
        {
            int a = Random.Range(0, animalesPrefab.Length);
            Vector3 PosicionGenerator = new Vector3(Random.Range(-xposicion1, xposicion2), 0, 20);
            Instantiate(animalesPrefab[a], PosicionGenerator, animalesPrefab[a].transform.rotation);
        }

    }



}
