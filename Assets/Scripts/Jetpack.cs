using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Jetpack : MonoBehaviour
{
    [SerializeField]
    private Transform Player;
    [SerializeField]
    private TextMeshProUGUI FuelIndicator;
    [SerializeField]
    private PlayerStatOB PlayerData;
    [SerializeField]
    private GameObject jetpackUI;
    private float offset = -0.5f;


    private void Update()
    {
        if (PlayerData.IsUsingJetpack)
        {
            this.gameObject.SetActive(true);
            jetpackUI.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
            jetpackUI.SetActive(false);
        }
    }
    void FixedUpdate()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y, Player.position.z + offset);
        FuelIndicator.text = "Fuel : " + PlayerData.curFuel;
    }
    
}
