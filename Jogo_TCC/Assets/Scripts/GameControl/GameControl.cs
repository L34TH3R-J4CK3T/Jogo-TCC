using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    public int health;

    private void Awake()
    {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }else if(control != this){
            Destroy(gameObject);
        }
    }

    public void Save(){
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath+"/GameSave_1.dat");

        PlayerData data = new PlayerData();
        data.health = health;

        bf.Serialize(file,data);
        file.Close();
    }

    public void Load(){
        if(File.Exists(Application.persistentDataPath+"/GameSave_1.dat")){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath+"/GameSave_1.dat", FileMode.Open);
            PlayerData data =(PlayerData)bf.Deserialize(file);
            file.Close();

            health = data.health;
            
        }
    }
}


[Serializable]
class PlayerData{
    public int health;
}
