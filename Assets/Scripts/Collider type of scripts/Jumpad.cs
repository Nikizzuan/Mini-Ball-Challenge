using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpad : MonoBehaviour
{

    [SerializeField]
    private float JumpadForce;

    private void OnTriggerEnter(Collider other)
        {

            if (!other.CompareTag("Player")) return;
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * JumpadForce, ForceMode.Impulse);

        }
    
    
}
