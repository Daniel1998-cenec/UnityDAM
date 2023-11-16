using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverJugador : MonoBehaviour
{

    public float desplazamientoHorizontal;
    public float velocidad = 10f;
    public GameObject ProyectilPrefab;
    public GameObject ProyectilPrefab1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(ProyectilPrefab, new Vector3(transform.position.x, 1.74f, transform.position.z), ProyectilPrefab.transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Instantiate(ProyectilPrefab1, new Vector3(transform.position.x, 0.762f, transform.position.z), ProyectilPrefab1.transform.rotation);
        }

        if (transform.position.x < -20)
        {
            transform.position = new Vector3(-20, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 20)
        {
            transform.position = new Vector3(20, transform.position.y, transform.position.z);
        }

        desplazamientoHorizontal = Input.GetAxis("Horizontal");
        //Mover al jugarod horizontalmente
        transform.Translate(Vector3.right * desplazamientoHorizontal * Time.deltaTime * velocidad);

    }

}
