using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    public GameObject player;
    private Player move;
    private bool isMove;

    private void Start()
    {
        move = player.GetComponent<Player>();
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        isMove = move.isMoving();
        animator.SetBool("isMove", isMove);
    }
}
