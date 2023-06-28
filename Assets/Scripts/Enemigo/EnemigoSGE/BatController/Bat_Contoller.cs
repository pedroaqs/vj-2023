using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_Contoller : MonoBehaviour
{
    public Transform player;
    public int speed = 20;
    float tiempoVel;

    Rigidbody2D rb;
    Vector3 direction;
    Vector3 Movimineto;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
            tiempoVel = Time.deltaTime;
           
           
            
            
    }

    public void ataqueEnemigo () {

        // if(sr.flipX == false){
        //       var KunaiPosition = transform.position + new Vector3(0,0,0);
        //       var gb = Instantiate(kunai, 
        //                            KunaiPosition,
        //                            Quaternion.identity)
        //                            as GameObject;
        //       var controller = gb.GetComponent<Kunai_Controller>();
        //       controller.SetRightDirection();
        //     }
        //     if(sr.flipX == true){
        //       var KunaiPosition = transform.position + new Vector3(-1,0,0);
        //       var gb = Instantiate(kunai, 
        //                            KunaiPosition,
        //                            Quaternion.identity)
        //                            as GameObject;
        //       var controller = gb.GetComponent<Kunai_Controller>();
        //       controller.SetLeftDirection();
        //     }

        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "cuadroDetecte"){
            MovimientoBat();
            rb.MovePosition(Movimineto);
        }
    }

    public void MovimientoBat(){

        direction = player.position - transform.position;
        direction.Normalize();
        Movimineto = transform.position + direction * speed * tiempoVel;
        // direction = player.position - transform.position;
        // direction.Normalize();
        // GetComponent<Rigidbody2D>().MovePosition(transform.position + direction * speed * tiempoVel);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Bala"){
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "Bala1"){
            Destroy(this.gameObject);
        }
    }

}
