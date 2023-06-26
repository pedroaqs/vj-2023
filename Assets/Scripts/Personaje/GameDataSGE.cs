using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameDataSGE
{
    public int Puntaje;
    public int Vida;
    public string Arma;
    public string Nivel1;
    public string Nivel2;
    public string Nivel3;
    public string Nivel4;
    public string Nivel5;

    public bool Bnivel1;
    public bool Bnivel2;
    public bool Bnivel3;
    public bool Bnivel4;
    public bool Bnivel5;


    
    
    public GameDataSGE(){
        Puntaje   = 0;
        Vida      = 100;
        Arma      = "Bala";
        Nivel1    = "Nivel 1";
        Nivel2    = "Nivel 2";
        Nivel3    = "Nivel 3";
        Nivel4    = "Nivel 4";
        Nivel5    = "Nivel 5";

        Bnivel1   = true;
        Bnivel2   = false;
        Bnivel3   = false;
        Bnivel4   = false;
        Bnivel5   = false;
        


    }

}
