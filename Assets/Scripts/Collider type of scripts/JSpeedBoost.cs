using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSpeedBoost : MonoBehaviour
{
    [SerializeField]
    private PlayerStatOB PlayerData;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        PlayerData.thrustForce = PlayerData.thrustForce + 0.1f;
       
    }
}
