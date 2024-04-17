using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData 
{
    public int scoreData;
    public string playerData;


    public GameData()
    {
        scoreData = 0;
        playerData = string.Empty;
    }
}
