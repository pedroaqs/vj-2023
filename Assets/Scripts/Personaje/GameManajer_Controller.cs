using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManajer_Controller : MonoBehaviour
{   
    Niveles nivelesSGE = new Niveles();
    GameDataSGE gamedata = new GameDataSGE();
    GameRepositorySGE gameRepository;
    
    public TMP_Text puntajeText;
    public TMP_Text vidaText;
    public TMP_Text armaText;
    public TMP_Text nivelText;

    string Mundo1 = "1. MundoInicio";
    string Mundo2 = "2. MundoDesert";
    string Mundo3 = "3. MundoAcuatico";
    string Mundo4 = "MundoMuerto";
    string Mundo5 = "Scena Mapa salto";
    string Mundo6 = "Scena Mapa Space";

    // Start is called before the first frame update
    void Start()
    {
        gameRepository = GetComponent<GameRepositorySGE>();
        gamedata = gameRepository.GetSaveDataSGE();
        LoadScreenTextsSGE();


    }

    void LoadScreenTextsSGE(){
        puntajeText.text = "Puntaje: " + gamedata.Puntaje;
        vidaText.text    = "Vidas: "   + gamedata.Vida;
        armaText.text    = "Arma: "    + gamedata.Arma;

        if(gamedata.Bnivel1 == true){
            nivelText.text   = "Nivel: "   + gamedata.Nivel1;
        }
        if(gamedata.Bnivel2 == true){
            nivelText.text   = "Nivel: "   + gamedata.Nivel2;
        }
        if(gamedata.Bnivel3 == true){
            nivelText.text   = "Nivel: "   + gamedata.Nivel3;
        }
        if(gamedata.Bnivel4 == true){
            nivelText.text   = "Nivel: "   + gamedata.Nivel4;
        }
        if(gamedata.Bnivel5 == true){
            nivelText.text   = "Nivel: "   + gamedata.Nivel5;
        }
        
        
    }

    public void GanarPuntos(int cant){
        gamedata.Puntaje += cant;
        Debug.Log("Puntajeeeee:" + gamedata.Puntaje);
        gameRepository.SaveDataSGE(gamedata);
        LoadScreenTextsSGE();
    }
    public void GanarVida(int cant){
        gamedata.Vida += cant;
        gameRepository.SaveDataSGE(gamedata);
        LoadScreenTextsSGE();
    }
    public void ArmaName(string name){
        gamedata.Arma = name;
        gameRepository.SaveDataSGE(gamedata);
        LoadScreenTextsSGE();
    }
            
    public void InicioMain(){
        SceneManager.LoadScene("1. Inicio");
    }
    public void Iniciar () {
        SceneManager.LoadScene(Mundo1);
    }
    public void Reanudar () {

        if(gamedata.Bnivel5 ==true){
            SceneManager.LoadScene(Mundo5);
        }else if (gamedata.Bnivel4 == true){
            SceneManager.LoadScene(Mundo4);
        }else if (gamedata.Bnivel3 == true){
            SceneManager.LoadScene(Mundo3);
        }else if (gamedata.Bnivel2 == true){
             SceneManager.LoadScene(Mundo2);
        }else if (gamedata.Bnivel1 == true){
             SceneManager.LoadScene(Mundo1);
        }          
    }
    public void Reiniciar () {
        gameRepository.DeleteGameSGE();
        SceneManager.LoadScene(Mundo1);
    }

    public void NivelBoton1 (){

    }
    public void NivelBoton2 (){

    }
    public void NivelBoton3 (){

    }
    public void NivelBoton4 (){

    }
    public void NivelBoton5 (){

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
