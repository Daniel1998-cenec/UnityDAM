using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ControlJuego : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> objetivos;
    public TextMeshProUGUI textoMarcador;
    private float retrasoGeneracion = 1.0f; //retraso de un segundo
    private int marcador;

    void Start()
    {
        marcador = 0;
        StartCoroutine(GenerarObjetivos());
        textoMarcador.text = "Puntos " + marcador;
        ActualizarMarcador(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator GenerarObjetivos() {
        //retardamos la tasa de espera de la generacion de enemigos
        while (true) { 
            yield return new WaitForSeconds(retrasoGeneracion);
            int index = Random.Range(0, objetivos.Count);//count es como length
            Instantiate(objetivos[index]); //cada segundo generará un objetivo, y mientras sea true
            //generará una figura.
        }
    }
    void ActualizarMarcador(int puntosASumar) {
        marcador += puntosASumar;
        textoMarcador.text = "Puntos " + marcador;
    }

}
