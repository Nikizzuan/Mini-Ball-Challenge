using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endgame : MonoBehaviour
{
    [SerializeField]
    private PlayerStatOB PlayerData;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        //EndGame
        //Update Scoreboard
        PlayerData.timeStart = false;
        PlayerData.ResetPositon(other.transform);
        GameManager.Instance.UpdateGameState(GameState.MainMenu);
        
        
    }
}
