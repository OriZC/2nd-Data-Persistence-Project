using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MainManager : MonoBehaviour, IDataPersistence
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    //LAst
    private int currentScore;

    
    public int bestScore;
    public string bestPlayer;

   

    //Player Info

    public Text currentPlayer;
    public Text bestScoreAndPlayer;




    private void Awake()
    {
        
        
        //ShowCurrentRecord();

    }


    void Start()
    {
  
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
        currentPlayer.text = DataManager.instance.playerName;
          
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
            
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
    }


    void AddPoint(int point)
    {
        m_Points += point;
        DataManager.instance.score = m_Points;
        ScoreText.text = $"Score : {m_Points}";
    }


    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        PrintGameRecord();
    }

    private void PrintGameRecord()
    {
        
        string currentPlayerName = currentPlayer.text;

       
            bestPlayer = currentPlayerName;
            bestScore = m_Points;

            bestScoreAndPlayer.text = $"Best Score - {bestPlayer}:{bestScore}";
   
    }

  

    public void SaveData(GameData data)
    {
        data.scoreData = bestScore;

    }

    public void LoadData( GameData data)
    {
        
        bestScore = data.scoreData;
    }

  
}
