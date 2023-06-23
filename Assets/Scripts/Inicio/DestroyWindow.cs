using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyWindow : MonoBehaviour
{
    private GameObject parentWindow;
	private GameObject callButton;
	private AudioSource musicaAudioSource;

	public void Start(){

	}

	public void DestroyWindowParent(){
		Debug.Log("destroy window");
		callButton = GameObject.Find("Opciones_Pre");
		InicioManagerController inicioManager = callButton.GetComponent<InicioManagerController>();
		inicioManager.windowIndicator = 0;
		Destroy(gameObject);
	}
    public void openJugar () {
        SceneManager.LoadScene("1. Inicio");
		musicaAudioSource.mute = true;

    }
}
