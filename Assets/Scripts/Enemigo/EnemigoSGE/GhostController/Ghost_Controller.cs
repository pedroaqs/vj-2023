using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Controller : MonoBehaviour
{   

    GameManajer_Controller GameManajerC;
    public Transform player;
    Animator animator;
    private int speed = 10;
    float tiempoVel;

    const int AnimacionG_Furia = 1;
    const int AnimacionG_Atack = 2;

    private bool bandActuar;
    int acumularBalas;
    // Start is called before the first frame update
    void Start()
    {   
        acumularBalas = 1;
        bandActuar = false;
        animator = GetComponent<Animator>();
        GameManajerC = GameObject.Find("GameManajer").GetComponent<GameManajer_Controller>();

    }

    // Update is called once per frame
    void Update()
    {
        tiempoVel = Time.deltaTime;
        
        if(bandActuar==true) {
            ChangeAnimation(AnimacionG_Atack);
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            GetComponent<Rigidbody2D>().MovePosition(transform.position + direction * speed * tiempoVel);   
        }
        

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "cuadroDetecte"){
            bandActuar = true;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        // if(other.gameObject.name == "cuadroDetecte"){
        
        //     // ChangeAnimation(AnimacionG_Atack);
        //     // Vector3 direction = player.position - transform.position;
        //     // direction.Normalize();
    
        //     // GetComponent<Rigidbody2D>().MovePosition(transform.position + direction * speed * tiempoVel);
        // }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.name == "cuadroDetecte"){
            ChangeAnimation(AnimacionG_Furia);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Bala"){
            Debug.Log("acumulaciones: "+ acumularBalas);
            if(acumularBalas ==10){
                Destroy(this.gameObject);
                GameManajerC.EstadoNivel(2,true);
                GameManajerC.GanarPuntos(50);
                GameManajerC.GanarVida(10);
            }
            acumularBalas++;
        }
        
    }


    private void ChangeAnimation(int animation){     
        animator.SetInteger("EstadoG",animation);
    }
    
}
