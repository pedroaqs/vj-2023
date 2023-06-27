using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HistoriaManagerController : MonoBehaviour
{
    public GameObject Historia1;
    public GameObject Historia2;
    public GameObject Historia3;
    public GameObject Historia4;
    public GameObject Historia5;
    public GameObject Historia6;
    public GameObject Historia7;
    public GameObject Historia8;
    public GameObject Historia9;
    public GameObject Historia10;

    int aux;

    // Start is called before the first frame update
    void Start()
    {
        aux = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MostrarHistoria(){
        aux++;
        if(aux == 2){
             Historia2.SetActive(true);  
        }
        if(aux == 3){
             Historia3.SetActive(true);  
        }
        if(aux == 4){
             Historia4.SetActive(true);  
        }
        if(aux == 5){
             Historia5.SetActive(true);  
        }
        if(aux == 6){
             Historia6.SetActive(true);  
        }
        if(aux == 7){
             Historia7.SetActive(true);  
        }
        if(aux == 8){
             Historia8.SetActive(true);  
        }
        if(aux == 9){
             Historia9.SetActive(true);  
        }
    }

    public void openInicio () {
        SceneManager.LoadScene("1. Inicio");
    }

}
