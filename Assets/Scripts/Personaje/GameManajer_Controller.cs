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
    string Mundo7 = "Ganaste";
    string Mundo8 = "Perdiste";

    private bool bandEst;
    private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        gameRepository = GetComponent<GameRepositorySGE>();
        gamedata = gameRepository.GetSaveDataSGE();
        sceneName = SceneManager.GetActiveScene().name;
        LoadScreenTextsSGE();


    }

    void LoadScreenTextsSGE(){
        puntajeText.text = "Puntaje: " + gamedata.Puntaje;
        vidaText.text    = "Vidas: "   + gamedata.Vida;
        armaText.text    = "Arma: "    + gamedata.Arma;

        if(gamedata.Bnivel1 == true && sceneName == Mundo1){
            nivelText.text   = "Mundo: "   + gamedata.Nivel1;
        }
        if(gamedata.Bnivel2 == true && sceneName == Mundo2){
            nivelText.text   = "Mundo: "   + gamedata.Nivel2;
        }
        if(gamedata.Bnivel3 == true && sceneName == Mundo3){
            nivelText.text   = "Mundo: "   + gamedata.Nivel3;
        }
        if(gamedata.Bnivel4 == true && sceneName == Mundo4){
            nivelText.text   = "Mundo: "   + gamedata.Nivel4;
        }
        if(gamedata.Bnivel5 == true && sceneName == Mundo5){
            nivelText.text   = "Mundo: "   + gamedata.Nivel5;
        }
        if(gamedata.Bnivel6 == true && sceneName == Mundo6){
            nivelText.text   = "Mundo: "   + gamedata.Nivel6;
        }
        
        
    }

    public void GanarPuntos(int cant){
        gamedata.Puntaje += cant;
        Debug.Log("Puntajeeeee:" + gamedata.Puntaje);
        gameRepository.SaveDataSGE(gamedata);
        LoadScreenTextsSGE();
    }
    public int ObtenerPuntos(){
        return gamedata.Puntaje;
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
                SceneManager.LoadScene(Mundo8);
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
        if (nivel == 7){
            gamedata.Bnivel7 = band;
        }
        gameRepository.SaveDataSGE(gamedata);
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
        if(gamedata.Vida>0){
            if(gamedata.Bnivel5 == true){
                 SceneManager.LoadScene(Mundo5);
            }
        }
    }
    public void NivelBoton6 (){
        if(gamedata.Vida>0){
            if(gamedata.Bnivel6 == true){
                SceneManager.LoadScene(Mundo6);
            }
        }
    }
    public void NivelBoton7 (){
        if(gamedata.Vida>0){
            if(gamedata.Bnivel7 == true){
                SceneManager.LoadScene(Mundo7);
            }
        }
    }

    public void InformacionHist(){
        SceneManager.LoadScene("HistoriaInicio 1");
    }
    public void SalirPlay(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
