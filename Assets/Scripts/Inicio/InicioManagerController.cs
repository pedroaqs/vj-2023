using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioManagerController : MonoBehaviour
{   

    public GameObject window;
	private GameObject canvas;
	public int windowIndicator;
	private GameObject newWindow;



    // Start is called before the first frame update
    void Start()
    {   

       
        //Window
        windowIndicator = 0;
		canvas = GameObject.Find("Canvas"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openJugar () {
        SceneManager.LoadScene("2. Jugar");
    }

    public void CreateWindow(){
		if(windowIndicator == 0) {
			windowIndicator += 1;

			Debug.Log ("---> Window ShareLink create");
			newWindow = Instantiate(window);
			newWindow.transform.SetParent(canvas.transform);
		}
	}
   
}

