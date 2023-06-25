using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarPortalEnemigos : MonoBehaviour
{
   Rigidbody2D rb;
     SpriteRenderer sr;
    Animator animator;
    public GameObject Enemigo;
    private float tiempoEnemigo =5f;
    private float tiempoultimo = 0f;
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
       tiempoultimo += Time.deltaTime;
       if(tiempoultimo >= tiempoEnemigo)
       {
        tiempoultimo = 0f;
        Instantiate(Enemigo, transform.position, Quaternion.identity);
       }
       
    }
}
