using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JFuelPlus : MonoBehaviour
{
    [SerializeField]
    private PlayerStatOB PlayerData;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        PlayerData.maxFuel = PlayerData.maxFuel + 4f;
      
    }
}
