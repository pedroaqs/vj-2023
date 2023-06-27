using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaPlayerController : MonoBehaviour
{
    private float velocity = 5;
    float realVelocity;
    GameManajer_Controller GameManajerC;
    
    Rigidbody2D rb;
    SpriteRenderer sr;
    bool band = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        GameManajerC = GameObject.Find("GameManajer").GetComponent<GameManajer_Controller>();
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
        band = true;
    }
    public void SetLeftDirection(){
        realVelocity = -velocity;
        band = false;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemigo"){
            GameManajerC.GanarPuntos(5);
            GameManajerC.GanarVida(2);
            Destroy(this.gameObject);

        }
        if(other.gameObject.tag == "BalaEnemiga"){
            Destroy(this.gameObject);

        }
        if(other.gameObject.tag == "Boss"){
            Destroy(this.gameObject);
        }
    }
}
