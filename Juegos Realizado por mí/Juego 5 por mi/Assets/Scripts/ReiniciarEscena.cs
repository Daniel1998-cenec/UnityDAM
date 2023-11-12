using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReiniciarEscena : MonoBehaviour
{
    // Start is called before the first frame update
    public Button botonReinicio; // Arrastra el botón en el Inspector
    void Start()
    {
        // Agrega un listener al botón que escucha el evento OnClick y llama al método ReiniciarLaEscena
        botonReinicio.onClick.AddListener(ReiniciarLaEscena);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReiniciarLaEscena()
    {
        int escenaActual = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(escenaActual);
    }
}
