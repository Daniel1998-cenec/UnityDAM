using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BotonDificultad : MonoBehaviour
{
    // Start is called before the first frame update
    private  Button boton;
    private ControlJuego controlJuego;
    public int dificultad;
    void Start()

    {
        boton = GetComponent<Button>();
        boton.onClick.AddListener(EstablecerDificultad);
        controlJuego = GameObject.Find("Gestor de Juegos").GetComponent<ControlJuego>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void EstablecerDificultad() {
        Debug.Log("establecer dificultad"+gameObject.name);
        controlJuego.IniciarJuego(dificultad);
    }
}
