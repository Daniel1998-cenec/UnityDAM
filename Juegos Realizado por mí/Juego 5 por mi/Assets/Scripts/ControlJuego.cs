using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class ControlJuego : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> objetivos;
    public TextMeshProUGUI textoMarcador;
    private float retrasoGeneracion = 1.0f; //retraso de un segundo
    private int marcador;
    public TextMeshProUGUI textoGameOver;
    public bool juegoEstaActivo;
    public Button botonreinicio;
    public GameObject pantallaInicio;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator GenerarObjetivos() {
        //retardamos la tasa de espera de la generacion de enemigos
        while (juegoEstaActivo) { 
            yield return new WaitForSeconds(retrasoGeneracion);
            int index = Random.Range(0, objetivos.Count);//count es como length
            Instantiate(objetivos[index]); //cada segundo generará un objetivo, y mientras sea true
            //generará una figura.
        }
    }

    public void ActualizarMarcador(int puntosASumar) {
        marcador += puntosASumar;
        textoMarcador.text = "Puntos " + marcador;
    }

    public void GameOver(){
        Debug.Log("HA TERMINADO EL JUEGO");
        textoGameOver.gameObject.SetActive(true);
        juegoEstaActivo = false;
        botonreinicio.gameObject.SetActive(true);
    }
    
    public void ReiniciarJuego(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IniciarJuego(int dificultad) 
    {
        retrasoGeneracion/=dificultad;
        juegoEstaActivo = true;
        StartCoroutine(GenerarObjetivos());//llamamos a la corrutina
        marcador = 0;//inicializamos el marcador
        ActualizarMarcador(0);
        pantallaInicio.gameObject.SetActive(false);
        Debug.Log(marcador);

    }


}
