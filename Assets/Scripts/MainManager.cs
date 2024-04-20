using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MainManager : MonoBehaviour, IDataPersistence
{
   
    public bool m_GameOver = false;
    public GameObject GameOverText;
    

    //Player Info

    public Text currentPlayer;
    public Text bestScoreAndPlayer;

    //variables for holding best player data
    public int bestScore;
    public string bestPlayer;

    public void Awake()
    {
        currentPlayer.text = DataManager.Instance.playerName;
       
    }


    private void PrintGameRecord()
    {

        int CurrentScore = DataManager.Instance.score;
        //if (CurrentScore > bestScore)
        //{
        bestPlayer = currentPlayer.text;
            bestScore = CurrentScore;

            bestScoreAndPlayer.text = $"Best Score - {bestPlayer}:{bestScore}";
        //}
    }

    private void SetBestPlayer()
    {
        if (bestPlayer == null && bestScore == 0)
        {
            bestScoreAndPlayer.text = "";
        }
        else
        {
            bestScoreAndPlayer.text = $"Best Score - {bestPlayer}:{bestScore}";
        }
    }

    public void GameOver()
    {

        m_GameOver = true;
        GameOverText.SetActive(true);
        PrintGameRecord();
   
    }
    public void SaveData(GameData data)
    {

        data.scoreData = DataManager.Instance.score;
        data.playerData = bestPlayer;
    }

    public void LoadData(GameData data)
    {

    }
}
