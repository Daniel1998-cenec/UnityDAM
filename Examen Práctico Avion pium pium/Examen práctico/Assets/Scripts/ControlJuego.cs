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
    public bool estarVivo = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReiniciarJuego()
    {
        Debug.Log("he tocado el boton");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
