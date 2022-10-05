using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private  Vector2 movementInput;
    private bool gamestart = false;
    private float threshold = -50f;
    

    [SerializeField]
    private PlayerStatOB PlayerData;

   
    bool held = false; // Is pressing and hold Space
    public bool grounded = true;
    private float disToGround = 1f;
    void Awake()
    {
        gamestart = false;
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
        rb = this.gameObject.GetComponent<Rigidbody>();
        PlayerData.curFuel = PlayerData.maxFuel;
        PlayerData.IsUsingJetpack = false;
    }

    private void GameManager_OnGameStateChanged(GameState state)
    {
        gamestart = state == GameState.Game;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!gamestart) return;

        if (transform.position.y < threshold)
        {
            PlayerData.ResetPositon(transform);
        }

        if (movementInput != Vector2.zero)
        {

            // moveball(movementInput);
             Vector3 direction = Vector3.forward * movementInput.y + Vector3.right * movementInput.x;
             rb.AddForce(direction * PlayerData.moveSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
            //  rb.AddForce(new Vector3(movementInput.x, 0f, movementInput.y) * PlayerData.moveSpeed);
        }

        if (PlayerData.IsUsingJetpack)
        {
            if (held && PlayerData.curFuel > 0f)
            {
                PlayerData.curFuel -= Time.deltaTime;
                rb.AddForce(Vector3.up * PlayerData.thrustForce, ForceMode.Impulse);
            }
            else if (grounded && PlayerData.curFuel < PlayerData.maxFuel)
            {
                PlayerData.curFuel += Time.deltaTime * PlayerData.rechargeRate;
            }

        }

        GroundCheck();


    }


    /// <summary>
    /// Check Player GameObject Detect GameObject via Raycast
    /// </summary>
    void GroundCheck() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, disToGround + 0.1f))
        {
            grounded = true;

        }
        else
        {
            grounded = false;
        }
    }




   public void OnMove(InputAction.CallbackContext movementValue)
    {
        movementInput = movementValue.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext JumpValue)
    {
        if (!PlayerData.IsUsingJetpack && grounded && JumpValue.performed )
        {
            rb.AddForce(Vector3.up * PlayerData.JumpForce,ForceMode.Impulse);
        }
        else {
            // used jetpack
            if (JumpValue.performed)
                held = true;
            if (JumpValue.canceled)
                held = false;
        }
    }

}
