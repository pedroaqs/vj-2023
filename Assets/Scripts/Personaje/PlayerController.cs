using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    const int animation_Idle     = 1; 
    const int animation_Jump     = 2;
    const int animation_Run      = 3;
    const int animation_Slide    = 5;
    const int animation_RunShoot = 6;
    const int animation_Duck     = 7;
    const int animation_Hurt     = 8;
    const int animation_Ladder   = 9;
    const int animation_Spin     =10;

    public int vCorrer;
    private int jump_Force = 200;

    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer sr;

    int aux = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Jugando");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {   

        //RightArrow
        if(Input.GetKey(KeyCode.RightArrow)){
            derecha();
            //Attack
            //if (Input.GetKey(KeyCode.C)){
            //    ChangeAnimation(Anima_RunShoot);
            //}
           

        }
        if(Input.GetKeyUp(KeyCode.RightArrow)){
             detener();
        }

        //LeftArrow
        if (Input.GetKey(KeyCode.LeftArrow)){

          izquierda();
            //Attack
            //  if (Input.GetKey(KeyCode.C)){
            //      ChangeAnimation(Anima_RunShoot);
            //  }
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow)){
             detener(); 
        }

         if (Input.GetKeyDown(KeyCode.Space) && aux<2){
           // rb.AddForce(new Vector2(0,jump_Force),ForceMode2D.Impulse);
            saltar();


            // if(IzquController.CanJumpPared()){
            //  // rb.AddForce(new Vector2(0,jump_Force),ForceMode2D.Impulse);
            //   rb.AddForce(transform.up * jump_Force);
            //   IzquController.JumpsPared();
            // }
            // if(DereController.CanJumpPared()){
            // //  rb.AddForce(new Vector2(0,jump_Force),ForceMode2D.Impulse);
            //   rb.AddForce(transform.up * jump_Force);
            //   DereController.JumpsPared();
            // }
     
        }
        if(Input.GetKeyUp(KeyCode.Space)){
             detener(); 
        }
         

    }

    public void ChangeAnimation(int animation){     
        animator.SetInteger("Estado",animation);
    }
    //Movilidad
    public void derecha(){
            rb.velocity = new Vector2(vCorrer, rb.velocity.y);
            sr.flipX = false;
            ChangeAnimation(animation_Run);
    }
    public void izquierda(){
            rb.velocity = new Vector2(-vCorrer, rb.velocity.y);
            sr.flipX = true;
            ChangeAnimation(animation_Run);
    }
    public void detener(){
        rb.velocity = new Vector2(0, rb.velocity.y);
        ChangeAnimation(1);
    }
    public void saltar () {
      //Space
           // rb.AddForce(new Vector2(0,jump_Force),ForceMode2D.Impulse);
            rb.AddForce(transform.up * jump_Force);
           // audioSource.PlayOneShot(SaltarClip);
            aux++;


            // if(IzquController.CanJumpPared()){
            //  // rb.AddForce(new Vector2(0,jump_Force),ForceMode2D.Impulse);
            //   rb.AddForce(transform.up * jump_Force);
            //   IzquController.JumpsPared();
            // }
            // if(DereController.CanJumpPared()){
            // //  rb.AddForce(new Vector2(0,jump_Force),ForceMode2D.Impulse);
            //   rb.AddForce(transform.up * jump_Force);
            //   DereController.JumpsPared();
            // }
        if(aux==2){
          ChangeAnimation(animation_Jump);
            
        }
    }
    

    void OnCollisionEnter2D(Collision2D other)
    {
        aux = 0;
    }
}
