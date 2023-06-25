using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar_Controller : MonoBehaviour
{

    private float velocity = 5;
    float realVelocity;
    
    Rigidbody2D rb;
    SpriteRenderer sr;
    bool band = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(realVelocity,0);
        sr.flipX = band;
        Destroy(this.gameObject,2);
    }
    public void SetRightDirection(){
        realVelocity = velocity;
        band = false;
    }
    public void SetLeftDirection(){
        realVelocity = -velocity;
        band = true;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            Destroy(this.gameObject);
        }
        
       
    }
}
