using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerStat", order = 1)]
public class PlayerStatOB : ScriptableObject
{
    public string PlayerName;
    public int Point;
    public float time;
    public bool timeStart;
    public float moveSpeed;
    public float JumpForce;
    public float curFuel;
    public float maxFuel = 4f;
    public float rechargeRate = 1f;
    public float thrustForce = 1f;
    public bool IsUsingJetpack;


    /// <summary>
    /// Reset Postion of the ball to origin when call
    /// </summary>
    /// <param name="ball"></param>
    public void ResetPositon(Transform ball) {

        ball.localPosition = new Vector3(0f, 0f, 0f);
        ball.transform.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.transform.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }


    public void Initialize()
    {

    Point = 0;
     time = 0f;
   // timeStart =false;
   moveSpeed = 5f;
   JumpForce = 4f;
   maxFuel = 4f;
    rechargeRate = 1f;
     thrustForce = 0.21f;
    IsUsingJetpack = false;
}

}

