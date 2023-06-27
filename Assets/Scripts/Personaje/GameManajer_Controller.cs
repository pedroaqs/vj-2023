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
    
    private bool isPaused = false;

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

    private bool bandEst;
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
        if(gamedata.Bnivel6 == true){
            nivelText.text   = "Nivel: "   + gamedata.Nivel6;
        }
        
        
    }

    public void GanarPuntos(int cant){
        gamedata.Puntaje += cant;
        Debug.Log("Puntajeeeee:" + gamedata.Puntaje);
        gameRepository.SaveDataSGE(gamedata);
        LoadScreenTextsSGE();
    }
    public void GanarVida(int cant){

        for(int i=0; i<cant;i++){
            if(gamedata.Vida < 100){
                gamedata.Vida++;
                LoadScreenTextsSGE();
            }    
        }
        
        gameRepository.SaveDataSGE(gamedata);
        LoadScreenTextsSGE();
    }
    public void PerderVida(int cant){
         for(int i=0; i<cant;i++){
            if(gamedata.Vida > 0){
                gamedata.Vida--;
                LoadScreenTextsSGE();
            }else{
                SceneManager.LoadScene("1. Inicio");
            }    
        }
        gameRepository.SaveDataSGE(gamedata);
        LoadScreenTextsSGE();
    }
    public void ArmaName(string name){
        gamedata.Arma = name;
        gameRepository.SaveDataSGE(gamedata);
        LoadScreenTextsSGE();
    }
    public string BalaEscogida(){
        return gamedata.Arma;
    }
    public void EstadoNivel(int nivel,bool band){
        if (nivel == 2){
            gamedata.Bnivel2 = band;
        }
        if (nivel == 3){
            gamedata.Bnivel3 = band;
        }
        if (nivel == 4){
            gamedata.Bnivel4 = band;
        }
        if (nivel == 5){
            gamedata.Bnivel5 = band;
        }
        if (nivel == 6){
            gamedata.Bnivel6 = band;
        }
        gameRepository.SaveDataSGE(gamedata);
    }


    public bool resulEstado (int nivel){
        if (nivel == 2){
            bandEst = gamedata.Bnivel2;
        }
        if (nivel == 3){
            bandEst = gamedata.Bnivel2;
        }
        if (nivel == 4){
            bandEst = gamedata.Bnivel4;
        }
        if (nivel == 5){
            bandEst = gamedata.Bnivel5;
        }
        if (nivel == 6){
            bandEst = gamedata.Bnivel6;
        }
        return bandEst;
    }

            
    public void InicioMain(){
        SceneManager.LoadScene("1. Inicio");
    }
    public void Pausar(){
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pausar el juego
            Debug.Log("El juego está pausado");
        }
        else
        {
            Time.timeScale = 1f; // Reanudar el juego
            Debug.Log("El juego ha sido reanudado");
        }
    }
    public void Iniciar () {
        if(gamedata.Vida>0){
            SceneManager.LoadScene(Mundo1);
        }
    }
    public void Reanudar () {
        if(gamedata.Vida>0){
            if(gamedata.Bnivel6 == true){
                SceneManager.LoadScene(Mundo6);
            }else if(gamedata.Bnivel5 ==true){
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
    }
    public void Reiniciar () {
        gameRepository.DeleteGameSGE();
        SceneManager.LoadScene(Mundo1);
    }

    public void NivelBoton1 (){
        if(gamedata.Vida>0){
            if(gamedata.Bnivel1 == true){
                SceneManager.LoadScene(Mundo1);
            }
        }
    }
    public void NivelBoton2 (){
        if(gamedata.Vida>0){
            if(gamedata.Bnivel2 == true){
                SceneManager.LoadScene(Mundo2);
            }
        }
    }
    public void NivelBoton3 (){
        if(gamedata.Vida>0){
            if(gamedata.Bnivel3 == true){
                SceneManager.LoadScene(Mundo3);
            }
        }
    }
    public void NivelBoton4 (){
        if(gamedata.Vida>0){
            if(gamedata.Bnivel4 == true){
                SceneManager.LoadScene(Mundo4);
            }
        }
    }
    public void NivelBoton5 (){
        if(gamedata.Bnivel5 == true){
            SceneManager.LoadScene(Mundo5);
        }
    }
    public void NivelBoton6 (){
        if(gamedata.Bnivel6 == true){
            SceneManager.LoadScene(Mundo6);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
