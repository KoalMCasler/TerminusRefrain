using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerStats playerStats;
    public Rigidbody2D rb;
    public Animator animator;
    public GameManager gameManager;
    public UIManager uIManager;
    public Vector2 moveDirection;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        uIManager = FindObjectOfType<UIManager>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        moveDirection.y = rb.velocity.y;
        rb.MovePosition(rb.position +  new Vector2(moveDirection.x * playerStats.moveSpeed * Time.deltaTime, rb.velocity.y));
        if(moveDirection.x > 0)
        {
            animator.SetFloat("inputX", 1);
            animator.SetBool("IsIdle", false);
        }
        if(moveDirection.x < 0)
        {
            animator.SetFloat("inputX", -1);
            animator.SetBool("IsIdle", false);
        }
        if(moveDirection.x == 0)
        {
            animator.SetBool("IsIdle", true);
        }
    }

    void OnMove(InputValue movementValue)
    {
        //Movement logic
        Vector2 moveVector2 = movementValue.Get<Vector2>();
        moveDirection.x = moveVector2.x;
    }
    void OnJump()
    {
        animator.SetTrigger("JumpPressed");
        rb.AddForce(transform.up * playerStats.jumpForce);
    }
}
