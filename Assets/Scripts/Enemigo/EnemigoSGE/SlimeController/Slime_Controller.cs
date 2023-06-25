using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Controller : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
     private int run_vel = 2;

    public float Pos;
    public float Pos2;

    public GameObject pared;
    public GameObject pared2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
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
            
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.name == "cuadroDetecte"){
            
        }
    }
}
