using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    //SINGLETON

  public static DataManager instance;

    public int bestScore;
    public string bestPlayer;

    public string playerName;
    public int score;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveData(ref GameData data)

    {
   
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
     
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            JsonUtility.FromJson<GameData>(json);

        }

    }

   
}
