using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameState State;

    [SerializeField]
    private PlayerStatOB PlayerData;

    [SerializeField]
    private TextMeshProUGUI PlayerName;
    [SerializeField]
    private TextMeshProUGUI PlayerPoints;
    [SerializeField]
    private TextMeshProUGUI CurrentPoints;
    [SerializeField]
    private TextMeshProUGUI PlayerCompletionTime;
    [SerializeField]
    private List<GameObject> Consumable = new List<GameObject>();

    public static event Action<GameState> OnGameStateChanged;
    void Awake()
    {
        Instance = this;
    
    }


   /// <summary>
   /// Update Game State 
   /// </summary>
   /// <param name="newState"></param>
   public void UpdateGameState(GameState newState) {
        State = newState;

        switch (newState)
        {
            case GameState.MainMenu:
                UpdateScore();
                break;
            case GameState.Game:
                PlayerData.Initialize();
                ResetConsumableVisible();
                break;
            default: 
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }


  
    private void UpdateScore() {

        // Only Create Static Score preview cuz of time constraints
        PlayerName.text = PlayerData.name;
        PlayerPoints.text = PlayerData.Point.ToString();
        PlayerCompletionTime.text = PlayerData.time.ToString();
    }


    /// <summary>
    /// Reset consumable gameobject to active
    /// </summary>
    private void ResetConsumableVisible() {


        foreach (var item in Consumable)
        {
            item.SetActive(true);
        }
    }

    private void Update()
    {
        if (PlayerData.timeStart)
        {
            PlayerData.time += Time.deltaTime;
            CurrentPoints.text = PlayerData.Point.ToString();
        }
    }
}

public enum GameState { 

    MainMenu,
    Game,


}
