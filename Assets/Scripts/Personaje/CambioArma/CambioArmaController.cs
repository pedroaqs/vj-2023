using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioArmaController : MonoBehaviour
{   
    GameManajer_Controller GameManajerC;
    Animator animator;
    int aux;
    // Start is called before the first frame update
    void Start()
    {
        aux = 0;
        animator = GetComponent<Animator>();
        GameManajerC = GameObject.Find("InicioManager").GetComponent<GameManajer_Controller>();

    }

    // Update is called once per frame
    void Update()
    {
        ElegirArma();
    }

    public void IzquierdaA(){
        if (aux >0)
        {
            Debug.Log("Armaaaaa: "+ aux);
            aux--;
            ChangeAnimation(aux);
        }
    }
    public void DerechaA(){
         if (aux <1)
        {   
            Debug.Log("Armaaaaa: "+ aux);
            aux++;
            ChangeAnimation(aux);
        }
        
    }

    public void ElegirArma(){
        if(aux==0){
            GameManajerC.ArmaName("Aro");
        }
        if(aux==1){
            GameManajerC.ArmaName("Misil");
        }
    }
    public void ChangeAnimation(int animation){     
        animator.SetInteger("EstadoA",animation);
    }
}
