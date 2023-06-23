using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowsManager : MonoBehaviour
{   
    public GameObject ventanaOP;
    // Start is called before the first frame update
    void Start()
    {
      //  ventanaOP.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MostrarVentana () {
        ventanaOP.SetActive(true);
    }
    public void OcultarVentana () {
        ventanaOP.SetActive(false);
    }
    public void openJugar () {
        SceneManager.LoadScene("2. Jugar");
    }
    public void openInicio () {
        SceneManager.LoadScene("1. Inicio");
    }
}
