using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JFuelMax : MonoBehaviour
{
    [SerializeField]
    private PlayerStatOB PlayerData;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        PlayerData.curFuel = PlayerData.maxFuel;
        
    }
}
