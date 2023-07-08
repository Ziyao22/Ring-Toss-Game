using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    private PlayerInput input;
    private Rigidbody rb;

    private bool isJump = false;
    private bool isBooster = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        input = new PlayerInput();

        input.Player.Enable();
        
        input.Player.jump.performed += Jump_performed;
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        if (obj.performed && !isJump)
        {
            isJump = true;
        }
    }

    public bool getJump()
    {
        return isJump;
    }

    public void setJump()
    {
        isJump = !isJump;
    }

    // Update is called once per frame
    public Vector2 PlayerMoveValue()
    {
        return input.Player.move.ReadValue<Vector2>();
    }

    // use booster
    public bool getBooster()
    {
        isBooster = input.Player.booster.ReadValue<float>() > 0.1f ? true : false;
        return isBooster;
    }

    public void setBooster()
    {
        isBooster = !isBooster;
    }
}
