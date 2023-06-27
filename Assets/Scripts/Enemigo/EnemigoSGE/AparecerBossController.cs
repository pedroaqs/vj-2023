using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerBossController : MonoBehaviour
{   

    //Desaparecer_Aparecer
    public GameObject objectToGhost;
    // public Transform aparecerPosicion;
    // public Transform desaparecerPosicion;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;



    public float aparecerTime    = 10f;
    public float desaparecerTime = 10f;

    //private bool isVisible = true;
    private float timer    = 0f;
    // Start is called before the first frame update
    void Start()
    {
         objectToGhost.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Desaparecer_Aparecer    
        timer += Time.deltaTime;
      //  Debug.Log("Random: "+ timer);

        // if (isVisible && timer >= aparecerTime)
        // {
        //     SetObjectPosition(desaparecerPosicion.position);
        //     objectToGhost.SetActive(false);
        //     isVisible = false;
        //     timer = 0f;
        // }
        // else if (!isVisible && timer >= desaparecerTime)
        // {
        //     SetObjectPosition(aparecerPosicion.position);
        //     objectToGhost.SetActive(true);
        //     isVisible = true;
        //     timer = 0f;
        // }

        if(timer >= aparecerTime) {
            int randomInt = Random.Range(0, 4);
            Debug.Log("Random: "+ randomInt);
            if(randomInt==0) {
                SetObjectPosition(pos1.position);
            }
            if(randomInt==1) {
                SetObjectPosition(pos2.position);
            }
            if(randomInt==2) {
                SetObjectPosition(pos3.position);
            }
            if(randomInt==3) {
                SetObjectPosition(pos4.position);
            }
            
            objectToGhost.SetActive(true);
            timer = 0f;
        }
    }

    private void SetObjectPosition(Vector3 position)
    {
        objectToGhost.transform.position = position;
    }
}
