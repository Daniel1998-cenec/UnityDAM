using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ControlJuego : MonoBehaviour
{
    public Button botonReinicio;
    public TextMeshProUGUI textoGameOver;
    public bool estarVivo=true;
    // Las variables que vamos a usar para el texto marcador
    public TextMeshProUGUI textoMarcador;
    private int marcador;



    // Start is called before the first frame update
    void Start()
    {
        marcador = 0;
        actualizarMarcador(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        
    }

    public void actualizarMarcador(int puntosASumar) 
    {
        marcador += puntosASumar;
        textoMarcador.text = "Puntos:" + marcador;
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
        
}
