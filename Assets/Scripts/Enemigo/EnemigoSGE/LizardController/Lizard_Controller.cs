using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard_Controller : MonoBehaviour
{   
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer sr;
    
    public GameObject bala;

    private int run_vel = 2;

    public float Pos;   
    public float Pos2;

    public GameObject pared;
    public GameObject pared2;
    
    int aux;
    bool band = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        GenerarParedes();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(run_vel,rb.velocity.y);
        
    }

    private void GenerarParedes(){
            var paredPosition = transform.position + new Vector3(Pos,0,0);
            var gb = Instantiate(pared,
                    paredPosition,
                    Quaternion.identity) as GameObject;
            var paredPosition2 = transform.position + new Vector3(Pos2,0,0);
            var gb2 = Instantiate(pared2,
                    paredPosition2,
                    Quaternion.identity) as GameObject;
    }
    private void DispararL(){
        
        if(sr.flipX == true){
            var balaposition = transform.position + new Vector3(1,0,0);
            var gb   = Instantiate(bala,balaposition,Quaternion.identity)
                        as GameObject;
            var controller = gb.GetComponent<Disparar_Controller>();
            controller.SetRightDirection();
        }
        if(sr.flipX == false){
            var balaposition = transform.position + new Vector3(-1,0,0);
            var gb   = Instantiate(bala,balaposition,Quaternion.identity)
                        as GameObject;
            var controller = gb.GetComponent<Disparar_Controller>();
            controller.SetLeftDirection();
        }

    }
    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Trigger");
        if(other.gameObject.tag == "Pared"){
        sr.flipX = true;
        run_vel = 2;
        }
        if(other.gameObject.tag == "Pared2"){
         sr.flipX = false;
         run_vel = -2;
        }
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "cuadroDetecte"){
            ChangeAnimation(2);
        aux = (int)(Time.time);
        if((aux%2) == 0){

            if(band == false){
                DispararL();
                band = true;
            }

        }else { band = false; }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.name == "cuadroDetecte"){
            ChangeAnimation(1);
        }
    }
    private void ChangeAnimation(int animation){     
        animator.SetInteger("EstadoL",animation);
    }
}
