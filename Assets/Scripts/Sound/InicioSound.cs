using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioSound : MonoBehaviour
{   

    public AudioClip musicaClip;
    private AudioSource musicaAudioSource;
    private bool band;
    int aux;
    // Start is called before the first frame update
    
    void Awake() 
    {
        DontDestroyOnLoad(gameObject);  
    }
    
    
    void Start()
    {
         //Sound
        musicaAudioSource = gameObject.AddComponent<AudioSource>();
        musicaAudioSource.clip = musicaClip;
     
        musicaAudioSource.loop = true;
        musicaAudioSource.Play();
        aux = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void muted (){
        if(aux == 0){
            musicaAudioSource.mute = true;
            aux++;
        }else{
            musicaAudioSource.mute = false;
            aux = 0;
        }
    }
}
