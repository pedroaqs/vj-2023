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
    public string Nivel6;

    public bool Bnivel1;
    public bool Bnivel2;
    public bool Bnivel3;
    public bool Bnivel4;
    public bool Bnivel5;
    public bool Bnivel6;
    public bool Bnivel7;


    
    
    public GameDataSGE(){
        Puntaje   = 0;
        Vida      = 100;
        Arma      = "Aro";
        Nivel1    = "Eros";
        Nivel2    = "Helios";
        Nivel3    = "Hefesto";
        Nivel4    = "Hermes";
        Nivel5    = "Zura";
        Nivel6    = "Cronos";

        Bnivel1   = true;
        Bnivel2   = false;
        Bnivel3   = false;
        Bnivel4   = false;
        Bnivel5   = false;
        Bnivel6   = false;
        Bnivel7   = false;
        


    }

}
