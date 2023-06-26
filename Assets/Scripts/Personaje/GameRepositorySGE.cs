using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameRepositorySGE : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveDataSGE(GameDataSGE data){
        string destination = Application.persistentDataPath + "/saveSGE.dat";
        FileStream file;

        if(File.Exists(destination)){
            file = File.OpenWrite(destination);
        }
        else{
            file = File.Create(destination);
        }
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file,data);
        file.Close();
    }
    public GameDataSGE GetSaveDataSGE(){
        Debug.Log("Loading file saveSGE.dat");

        string destination = Application.persistentDataPath + "/saveSGE.dat";
        FileStream file;

        if(File.Exists(destination)){
            file = File.OpenRead(destination);
        }
        else {
            return new GameDataSGE();
        }
        BinaryFormatter bf = new BinaryFormatter();
        GameDataSGE data = (GameDataSGE) bf.Deserialize(file);
        file.Close();

        return data;

    }
    public void DeleteGameSGE(){
        string destination = Application.persistentDataPath + "/saveSGE.dat";
        if(File.Exists(destination)){
            File.Delete(destination);
        }
    }
}
