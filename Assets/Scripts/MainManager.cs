using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MainManager : MonoBehaviour, IDataPersistence
{
   
    public bool m_GameOver = false;
    public GameObject GameOverText;
    private GameData gameData;

    //Player Info

    public Text currentPlayer;
    public Text bestScoreAndPlayer;

    //variables for holding best player data
    public int bestScore;
    public string bestPlayer;

    

    public void Awake()
    {
        
        currentPlayer.text = DataManager.Instance.playerName;
        gameData = DataManager.Instance.gameData;
        SetBestPlayer();
        

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
       
    }


    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        
        DataManager.Instance.LoadGame();
        bestScoreAndPlayer.text = $"Best Score - {gameData.playerData} : {gameData.scoreData}";
    }

    private void CheckRecord()
    {

        int CurrentScore = DataManager.Instance.score;
        if (CurrentScore > gameData.scoreData)
        {
            bestPlayer = currentPlayer.text;
            bestScore = CurrentScore;

            bestScoreAndPlayer.text = $"Best Score - {bestPlayer}:{bestScore}";
        }
        else
        {
            bestPlayer = gameData.playerData;
            bestScore = gameData.scoreData;
        }
    }
    private void SetBestPlayer()
    {
        if (bestPlayer == null && bestScore == 0)
        {
            bestScoreAndPlayer.text = "";
        }
        else
        {
            bestScoreAndPlayer.text = $"Best Score - {gameData.playerData} : {gameData.scoreData}";
        }
    }
    public void GameOver()
    {

        m_GameOver = true;
        GameOverText.SetActive(true);
        CheckRecord();
        
   
    }
    public void SaveData(GameData data)
    {

        data.scoreData = bestScore;
        data.playerData = bestPlayer;
    }

    public void LoadData(GameData data)
    {
        DataManager.Instance.score = data.scoreData;
        bestPlayer = data.playerData;
    }
}
