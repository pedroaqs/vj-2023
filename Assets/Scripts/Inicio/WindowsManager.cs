using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowsManager : MonoBehaviour
{   
    public GameObject ventanaOP;
    public GameObject ventanaJugar;
    public GameObject ventanaNiveles;
    public GameObject ventanaPlayer;



    // Start is called before the first frame update
    void Start()
    {
      //  ventanaOP.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //OPCIONES***********************************
    public void MostrarVentana () {
        ventanaOP.SetActive(true);
    }
    public void OcultarVentana () {
        ventanaOP.SetActive(false);
    }
    //JUGAR/*************************************
    public void MostrarVJugar () {
        ventanaJugar.SetActive(true);
        ventanaPlayer.SetActive(false);
    }
    public void OcultarVJugar () {
        ventanaJugar.SetActive(false);
        ventanaPlayer.SetActive(true);
    }
    //NIVELES/***********************************
    public void MostrarVNiveles () {
        ventanaNiveles.SetActive(true);
        ventanaPlayer.SetActive(false);
    }
    public void OcultarVNiveles () {
        ventanaNiveles.SetActive(false);
        ventanaPlayer.SetActive(true);
    }


    public void openJugar () {
        SceneManager.LoadScene("2. Jugar");
    }
    public void openInicio () {
        SceneManager.LoadScene("1. Inicio");
    }
}
