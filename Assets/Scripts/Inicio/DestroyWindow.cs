using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyWindow : MonoBehaviour
{
    private GameObject parentWindow;
	private GameObject callButton;


	public void Start(){

	}

	public void DestroyWindowParent(){
		Debug.Log("destroy window");
		callButton = GameObject.Find("Opciones");
		callButton.GetComponent<InicioManagerController>().windowIndicator = 0;
		Destroy(this.transform.parent.transform.gameObject);
	}
    public void openJugar () {
        SceneManager.LoadScene("1. Inicio");
    }
}
