using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackOrb : MonoBehaviour
{
    [SerializeField]
    private PlayerStatOB PlayerData;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
      
        PlayerData.IsUsingJetpack = true;

    
        this.gameObject.SetActive(false);

    }


}
