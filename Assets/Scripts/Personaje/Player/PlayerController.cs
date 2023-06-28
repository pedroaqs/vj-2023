using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    GameManajer_Controller GameManajerC;
    public Transform posInicio;
    const int animation_Idle     = 1; 
    const int animation_Jump     = 2;
    const int animation_Run      = 3;
    const int animation_Slide    = 5;
    const int animation_RunShoot = 6;
    const int animation_Duck     = 7;
    const int animation_Hurt     = 8;
    const int animation_Ladder   = 9;
    const int animation_Spin     =10;

    public GameObject bala;
    public GameObject bala1;


    public int vCorrer;
    private int jump_Force = 200;

    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Transform tf;

    int aux = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Jugando");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        tf = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        GameManajerC = GameObject.Find("GameManajer").GetComponent<GameManajer_Controller>();

    }

    // Update is called once per frame
    void Update()
    {   

        //RightArrow
        if(Input.GetKey(KeyCode.RightArrow)){
            derecha();
            //Attack
            if (Input.GetKey(KeyCode.A)){
               ChangeAnimation(animation_RunShoot);
            }
           

        }
        if(Input.GetKeyUp(KeyCode.RightArrow)){
             detener();
        }

        //LeftArrow
        if (Input.GetKey(KeyCode.LeftArrow)){

          izquierda();
            //Attack
            if (Input.GetKey(KeyCode.A)){
               ChangeAnimation(animation_RunShoot);
            }
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
        if(Input.GetKeyDown(KeyCode.A)){
            ChangeAnimation(animation_RunShoot);
            Disparar();
        }
        if(Input.GetKeyUp(KeyCode.A)){
             detener(); 
        }
        if(Input.GetKeyUp(KeyCode.Space)){
             detener(); 
        }
        if(Input.GetKey(KeyCode.Q)){
             Agacharse();
        }
        if(Input.GetKeyUp(KeyCode.Q)){
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
    public void Disparar (){

        if(GameManajerC.BalaEscogida() == "Aro"){
            if(sr.flipX == false){
                var balaposition = transform.position + new Vector3(1,0,0);
                var gb   = Instantiate(bala,balaposition,Quaternion.identity)
                        as GameObject;
                var controller = gb.GetComponent<BalaPlayerController>();
                controller.SetRightDirection();
            }
            if(sr.flipX == true){
                var balaposition = transform.position + new Vector3(-1,0,0);
                var gb   = Instantiate(bala,balaposition,Quaternion.identity)
                        as GameObject;
                var controller = gb.GetComponent<BalaPlayerController>();
                controller.SetLeftDirection();
            }
        }
        if(GameManajerC.BalaEscogida() == "Misil"){
            if(sr.flipX == false){
                var balaposition1 = transform.position + new Vector3(1,0,0);
                var gb   = Instantiate(bala1,balaposition1,Quaternion.identity)
                        as GameObject;
                var controller = gb.GetComponent<BalaPlayerController>();
                controller.SetRightDirection();
            }
            if(sr.flipX == true){
                var balaposition1 = transform.position + new Vector3(-1,0,0);
                var gb   = Instantiate(bala1,balaposition1,Quaternion.identity)
                        as GameObject;
                var controller = gb.GetComponent<BalaPlayerController>();
                controller.SetLeftDirection();
            }
        }
    }
    private void Agacharse(){
        ChangeAnimation(animation_Slide);
    }
    private void RegresarPuntoInicio(Vector3 position)
    {
        tf.transform.position = position;
    }
    void OnCollisionEnter2D(Collision2D other)
    {           
        aux = 0;
        if(other.gameObject.tag == "Enemigo"){
            GameManajerC.PerderVida(5);
        }
        if(other.gameObject.tag == "BalaEnemiga"){
            Debug.Log("Balaaaaaaaaaaaaa");
            GameManajerC.PerderVida(2);
        }
        if(other.gameObject.tag == "Lava"){
            GameManajerC.PerderVida(2);
        }
        if(other.gameObject.tag == "Boss"){
            GameManajerC.PerderVida(5);
        }
        if(other.gameObject.tag == "Vacio"){
            RegresarPuntoInicio(posInicio.position);
            GameManajerC.PerderVida(2);
        }
        if(other.gameObject.tag == "Destruir"){
            RegresarPuntoInicio(posInicio.position);
            GameManajerC.PerderVida(2);
        }

        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Faros"){
            GameManajerC.GanarPuntos(50);    
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Puerta1" && Input.GetKey(KeyCode.E) ){
            GameManajerC.NivelBoton2();    
        }
        if(other.gameObject.tag == "Puerta2" && Input.GetKey(KeyCode.E) && GameManajerC.ObtenerPuntos() >=300 ){
            GameManajerC.EstadoNivel(3,true);
            GameManajerC.NivelBoton3();    
        }
        if(other.gameObject.tag == "Puerta3" && Input.GetKey(KeyCode.E) ){  
            GameManajerC.NivelBoton4();    
        }
        if(other.gameObject.tag == "Puerta4" && Input.GetKey(KeyCode.E)  && GameManajerC.ObtenerVidas() >=50){
            GameManajerC.EstadoNivel(5,true);
            GameManajerC.NivelBoton5();    
        }
        if(other.gameObject.tag == "Puerta5" && Input.GetKey(KeyCode.E)  && GameManajerC.ObtenerPuntos() >= 500 && GameManajerC.ObtenerVidas() >= 50){
            GameManajerC.EstadoNivel(6,true);
            GameManajerC.NivelBoton6();    
        }
        if(other.gameObject.tag == "Puerta6" && Input.GetKey(KeyCode.E) ){
            GameManajerC.EstadoNivel(7,true);
            GameManajerC.NivelBoton7();    
        }        
    }
 
}
