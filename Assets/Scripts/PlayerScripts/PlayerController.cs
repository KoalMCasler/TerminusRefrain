using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerStats playerStats;
    public Rigidbody2D rb;
    public Collider2D playerCollider;
    public Animator animator;
    public GameManager gameManager;
    public UIManager uIManager;
    public Vector2 moveDirection;
    public bool isGrounded;
    public bool isGrabingLedge;
    public Vector3 activeOffset;
    public Vector3 leftOffset;
    public Vector3 rightOffset;
    public GameObject ledge;
    public float climbDuration = .5f;
    public Vector3 topOfLedge;
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
        rb.velocity = new Vector3(moveDirection.x * playerStats.moveSpeed * Time.deltaTime, rb.velocity.y);
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
        if(isGrabingLedge == true)
        {
            this.gameObject.transform.position = activeOffset;
            animator.SetBool("IsIdle", true);
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 moveVector2 = movementValue.Get<Vector2>();
        //Movement logic
        if(!isGrabingLedge)
        {
            moveDirection.x = moveVector2.x;
        }
        if(isGrabingLedge)
        {
            if(moveVector2.y > 0)
            {
                LedgeClimb();
            }
            if(moveVector2.y < 0)
            {
                isGrabingLedge = false;
                ledge = null;
                topOfLedge = Vector3.zero;
                activeOffset = Vector3.zero;
            }
        }
    }

    void OnJump()
    {
        if(isGrounded == true && isGrabingLedge == false)
        {
            animator.SetTrigger("JumpPressed");
            rb.AddForce(transform.up * playerStats.jumpForce);
        }
        else
        {
            Debug.Log("Not groundd");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "GrabPoint" && col.gameObject.transform.position.y > this.gameObject.transform.position.y)
        {
            ledge = col.gameObject;
            topOfLedge = ledge.transform.position;
            topOfLedge.y = ledge.transform.position.y * 1.25f;
            if(ledge.transform.position.x < this.gameObject.transform.position.x)
            {
                activeOffset = leftOffset + ledge.transform.position;
            }
            if(ledge.transform.position.x > this.gameObject.transform.position.x)
            {
                activeOffset = rightOffset + ledge.transform.position;
            }
            isGrabingLedge = true;
            Debug.Log("Grab point hit");
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Terrain"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Terrain"))
        {
            isGrounded = false;
        }
    }

    void LedgeGrab()
    {
        
    }
    void LedgeClimb()
    {
        float climbTime = 0;
        Vector2 startValue = transform.position;
        while (climbTime <= climbDuration)
        {
            transform.position = Vector2.Lerp(startValue, topOfLedge, climbTime / climbDuration);
            climbTime += Time.deltaTime;  
        }
        isGrabingLedge = false;
        ledge = null;
        topOfLedge = Vector3.zero;
        activeOffset = Vector3.zero;
    }
}
