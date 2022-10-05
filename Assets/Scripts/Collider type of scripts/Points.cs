using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField]
    private PlayerStatOB PlayerData;
    [SerializeField]
    private int PointValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        PlayerData.Point = PlayerData.Point + PointValue;
        this.gameObject.SetActive(false);
    }
}
