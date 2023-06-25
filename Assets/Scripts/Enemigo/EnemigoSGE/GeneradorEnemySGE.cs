using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemySGE : MonoBehaviour
{
    public GameObject enemySGE;
    public Transform player;
    int aux;
    bool band =  false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("Generar Enemy" + Time.time);
        aux = (int)(Time.time);
        if((aux%10) == 0){

            if(band == false){
                //Debug.Log("Tiempo de Generacion" + aux);
                var EnemyPosition = transform.position + new Vector3(-1,0,0);
                var gb = Instantiate(enemySGE,
                                    EnemyPosition,
                                    Quaternion.identity)
                                    as GameObject;
                // var controller = gb.GetComponent<Bat_Contoller>();
                // controller.MovimientoBat();
                band = true;
            }

        }else { band = false; }

    }
}
