using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject menuPanel;

    [SerializeField]
    private PlayerStatOB PlayerData;
    [SerializeField]
    private TMP_InputField PlayerName;

    // Start is called before the first frame update
    void Awake()
    {
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }


    /// <summary>
    /// When State change the funtion will be call 
    /// </summary>
    /// <param name="state"></param>
    private void GameManager_OnGameStateChanged(GameState state)
    {
        menuPanel.SetActive(state == GameState.MainMenu);
        menuPanel.SetActive(!(state == GameState.Game));
    }

    public void StartGame() {
        // menuPanel.SetActive(false);
        if (PlayerName.text == "") return;
        PlayerData.PlayerName = PlayerName.text;
        PlayerData.time = 0f;
        PlayerData.timeStart = true;
        GameManager.Instance.UpdateGameState(GameState.Game);
    }


  
}
