using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientos : MonoBehaviour
{
     SpriteRenderer sr;
    Animator animator;
    public float velocity = 5;
    const int ANIMATION_CAMINAR = 0;
 
 
    private Rigidbody2D rb; // Cuerpo �f�sico� de los enemigos
    private int direction;
    private int cont1 = 0;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2 (-velocity,0);
        //ChangeAnimation(ANIMATION_CAMINAR);
 
    }

     private void ChangeAnimation(int animation)
    {
        animator.SetInteger("Estado0", animation);
       

    }
     void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag =="Player" ){
          
        }

         if (other.gameObject.tag == "Bala")
        {
            cont1++;
            if (cont1 >= 1)
            {
                Destroy(this.gameObject);

            }
        }
        if(other.gameObject.tag == "Bala1"){
            Destroy(this.gameObject,2);
        }
          if (other.gameObject.tag == "Destruir")
        {
                Destroy(this.gameObject);
                
            
        }
          if (other.gameObject.tag == "Bala")
        {
                Destroy(this.gameObject);
                
            
        }

     
    }

    void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag == "loopEnemigoIzquierda"){
            velocity *= -1;
           // ChangeAnimation(ANIMATION_CAMINAR);
            sr.flipX = true;    


        }
        if(other.gameObject.tag == "loopEnemigoDerecha"){
            velocity *= -1;
          //  ChangeAnimation(ANIMATION_CAMINAR);
              sr.flipX = false;  

        }
         if (other.gameObject.tag == "Destru")
        {
                Destroy(this.gameObject);
                
            
        }

        

       
    }

}
