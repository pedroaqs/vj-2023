using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Botones_JugarManager : MonoBehaviour
{
    public TMP_Text textPuntajeJugar;
    public TMP_Text textVidaJugar;
    public TMP_Text textNivelJugar;
    public TMP_Text textArmaJugar;

    int puntaje;
    int vida;
    int nivel;
    string arma;

    string guardarScena_R;
    // Start is called before the first frame update
    void Start()
    {
        puntaje = 5000;
        vida    = 10;
        nivel   = 5;
        arma    = "RAYO";
        guardarScena_R = "2. MundoDesert";
        Print_PuntajeJugar();
        Print_VidaJugar();
        Print_NivelJugar();
        Print_ArmaJugar();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Iniciar () {
        SceneManager.LoadScene("1. MundoInicio");
    }
    public void Reanudar () {
        SceneManager.LoadScene(guardarScena_R);
    }
    public void Reiniciar () {
        SceneManager.LoadScene("1. MundoInicio");
    }
    public void ArmaAtras () {
        
    }
    public void ArmaDelante () {
        
    }
    public void StatsGuardados () {
        
    }

    private void Print_PuntajeJugar () {
        textPuntajeJugar.text = "Puntaje : "+ puntaje;
    }
    private void Print_VidaJugar () {
        textVidaJugar.text    = "Vida : "   + vida;
    }
    private void Print_NivelJugar () {
        textNivelJugar.text   = "Nivel : "  + nivel;
    }
    private void Print_ArmaJugar () {
        textArmaJugar.text    = "Arma : "   + arma;
    }
}
