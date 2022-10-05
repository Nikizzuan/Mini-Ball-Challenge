using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JRechargeRate : MonoBehaviour
{
    [SerializeField]
    private PlayerStatOB PlayerData;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        PlayerData.rechargeRate = PlayerData.rechargeRate + 1f;
        Destroy(this);
    }
}
