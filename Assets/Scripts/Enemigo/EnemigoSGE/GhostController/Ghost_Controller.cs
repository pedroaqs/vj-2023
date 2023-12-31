using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost_Controller : MonoBehaviour
{   

    GameManajer_Controller GameManajerC;
    public Transform player;
    Animator animator;
    public int speed = 7;
    float tiempoVel;

    const int AnimacionG_Furia = 1;
    const int AnimacionG_Atack = 2;

    private bool bandActuar;
    int acumularBalas;
    private string sceneName;
    int auxV;
    bool bandV =  false;
    // Start is called before the first frame update
    void Start()
    {   
        acumularBalas = 1;
        bandActuar = false;
        sceneName = SceneManager.GetActiveScene().name;
        animator = GetComponent<Animator>();
        GameManajerC = GameObject.Find("GameManajer").GetComponent<GameManajer_Controller>();

    }

    // Update is called once per frame
    void Update()
    {
        tiempoVel = Time.deltaTime;
       // Debug.Log("mmmmmmmmm: " + tiempoVel*100);
        if(bandActuar==true) {
            ChangeAnimation(AnimacionG_Atack);
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            GetComponent<Rigidbody2D>().MovePosition(transform.position + direction * speed * tiempoVel);   
        }

        auxV = (int)(Time.time);
        if((auxV%2) == 0){

            if(bandV == false){

                if(sceneName == "1. MundoInicio"){
                    speed = 7;    
                }
                if(sceneName == "3. MundoAcuatico"){
                    speed = 50;   
                }
                
                bandV = true;
            }

        }else { bandV = false; }


        

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
                if(sceneName == "1. MundoInicio"){
                    GameManajerC.EstadoNivel(2,true);    
                }
                if(sceneName == "3. MundoAcuatico"){
                    GameManajerC.EstadoNivel(4,true);    
                }
                
                GameManajerC.GanarPuntos(50);
                GameManajerC.GanarVida(10);
                Destroy(this.gameObject);
            }
            acumularBalas++;
        }
        if(other.gameObject.tag == "Bala1"){
            Debug.Log("acumulaciones: "+ acumularBalas);
            speed = 2;
            if(acumularBalas ==15){
                if(sceneName == "1. MundoInicio"){
                    GameManajerC.EstadoNivel(2,true);    
                }
                if(sceneName == "3. MundoAcuatico"){
                    GameManajerC.EstadoNivel(4,true);    
                }
                
                GameManajerC.GanarPuntos(50);
                GameManajerC.GanarVida(10);
                Destroy(this.gameObject);
            }
            acumularBalas++;
        }
        
    }


    private void ChangeAnimation(int animation){     
        animator.SetInteger("EstadoG",animation);
    }
    
}
