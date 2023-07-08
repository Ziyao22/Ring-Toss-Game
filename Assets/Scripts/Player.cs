using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float RotationConst = 9.0f;

    [SerializeField]
    private float MoveSpeed = 5.0f;



    [SerializeField]
    private PlayerMove PlayerMove;
    private float playerHeight = 2f;

    [SerializeField]
    private float detectDist = .7f;

    private bool isMove = false;
    private bool canMove = true; //false

    private Vector3 moveVect;

    private bool isJump = false;
    private bool canJump = false;

    private Rigidbody rb;

    public GameObject energy_bar_controller;
    private bool isboosting = false;
    private float boostTimer = 0f;
    //private float boostSpeed = 7.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        moveHandle();
        JumpHandle();

        Debug.Log("canJump" + canJump + "canMove" + canMove);

        if (isJump)
        {
            if (canJump)
            {
                rb.AddForce((Vector3.up + moveVect) * MoveSpeed, ForceMode.Impulse);
                
                PlayerMove.setJump();
            }
        }
        else if (canMove)
        {
            rb.MovePosition(rb.position + moveVect * MoveSpeed * Time.fixedDeltaTime);
            isMove = moveVect != Vector3.zero;
            transform.forward = Vector3.Slerp(transform.forward, moveVect, RotationConst * Time.fixedDeltaTime);
        }

        if (PlayerMove.getBooster())
        {
            if (!isboosting && isMove)
            {
                var num = energy_bar_controller.GetComponent<energyBarController>().energy_num;
                if (num > 0)
                {
                    energy_bar_controller.GetComponent<energyBarController>().energy_num -= 1;
                    isboosting = true;
                    MoveSpeed = 15.0f;
                    PlayerMove.setBooster();
                }
            }
        }

        if (isboosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 0.5f)
            {
                isboosting = false;
                boostTimer = 0f;
                MoveSpeed = 5.0f;
            }
        }
        
    }

    public void moveHandle()
    {
        Vector2 inputVec = PlayerMove.PlayerMoveValue();
        inputVec.Normalize();
        moveVect = new Vector3(inputVec.x, 0, inputVec.y);

        float moveDist = Time.fixedDeltaTime * MoveSpeed;
        //canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, detectDist, moveVect, moveDist);
    }

    public void JumpHandle()
    {
        isJump = PlayerMove.getJump();
        float jumpDist = 0.1f;
        canJump = Physics.Raycast(transform.position, Vector3.down, jumpDist);

    }

    public bool isMoving()
    {
        return isMove;
    }



    // collision with booster
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "booster")
        {
            Destroy(other.gameObject);
            var num = energy_bar_controller.GetComponent<energyBarController>().energy_num;
            if (num < 5)
            {
                energy_bar_controller.GetComponent<energyBarController>().energy_num += 1;
            }
        }
    }
}
