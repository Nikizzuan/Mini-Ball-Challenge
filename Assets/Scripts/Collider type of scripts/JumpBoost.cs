using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    [SerializeField]
    private PlayerStatOB PlayerData;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        PlayerData.JumpForce = PlayerData.JumpForce + 6f;
        this.gameObject.SetActive(false);
    }
}
