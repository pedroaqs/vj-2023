using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Controller : MonoBehaviour
{   

    public Transform player;
    Animator animator;
    private int speed = 10;
    float tiempoVel;

    const int AnimacionG_Furia = 1;
    const int AnimacionG_Atack = 2;

    private bool bandActuar;
    // Start is called before the first frame update
    void Start()
    {   
        bandActuar = false;
        animator = GetComponent<Animator>();

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
    private void ChangeAnimation(int animation){     
        animator.SetInteger("EstadoG",animation);
    }
    
}
