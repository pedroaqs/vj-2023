using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InicioSound : MonoBehaviour
{   

    public AudioClip musicaClip;
    private AudioSource musicaAudioSource;

    int aux;
    int nivelVol;

    private static InicioSound instance;

 
    public TMP_Text vol;
    // Start is called before the first frame update
    
    // void Awake() 
    // {
    //     DontDestroyOnLoad(gameObject);  
    // }
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        
        PlaySound();
        nivelVol = 100;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void muted (){
        if(aux == 0){
            musicaAudioSource.mute = true;
            vol.text = "0";
            aux++;
        }else{
            musicaAudioSource.mute = false;
            vol.text = nivelVol.ToString();
            aux = 0;
        }
    }

    public void PlaySound()
    {
         //Sound
        musicaAudioSource = gameObject.AddComponent<AudioSource>();
        musicaAudioSource.clip = musicaClip;
        musicaAudioSource.loop = true;
        musicaAudioSource.Play();
        aux = 0;
    }

    public void StopSound()
    {
         musicaAudioSource.Stop();
    }

    public void AumentarVolumen () {
        if(musicaAudioSource.volume < 1f) {
            nivelVol += 10;
            musicaAudioSource.volume += 0.1f;
            vol.text = nivelVol.ToString();
    
            
        }
    }
    public void DisminuirVolumen () {
        if(musicaAudioSource.volume > 0f) {
            nivelVol -= 10;
            musicaAudioSource.volume -= 0.1f;
            vol.text = nivelVol.ToString();
           
        }
    }

    public void cambiarText () {
        vol.text = "VOLUMEN";
        
    }


}
