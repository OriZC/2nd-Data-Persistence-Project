using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    //SINGLETON

  public static DataManager instance;


    
    public string playerName;
    public int score;


    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveData(GameData data)

    {
   
        string dataToSave = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", dataToSave);
    }

    public void LoadData()
    {

    }

   
}
