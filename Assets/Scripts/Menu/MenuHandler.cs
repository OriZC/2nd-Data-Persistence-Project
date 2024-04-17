using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour, IDataPersistence
{
    [SerializeField] Text playerNameInput;

    public void EnterPlayerName()
    {
        DataManager.instance.playerName = playerNameInput.text;
    }
   public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void LoadData(GameData data)
    {
        playerNameInput.text = data.playerData;
    }

    public void SaveData(GameData data)
    {
        data.playerData = playerNameInput.text;
    }
}
