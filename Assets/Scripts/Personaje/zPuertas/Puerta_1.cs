using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta_1 : MonoBehaviour
{   

    GameManajer_Controller GameManajerC;
    // Start is called before the first frame update
    void Start()
    {
        GameManajerC = GameObject.Find("GameManajer").GetComponent<GameManajer_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(Input.GetKeyDown(KeyCode.E)){
            GameManajerC.NivelBoton2();    
        }
        
    }
}
