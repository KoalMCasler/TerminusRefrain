using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    [HideInInspector]
    public bool isFacingRight;
    public bool inputEnabled;
    [HideInInspector]
    public bool isGrounded;
    [HideInInspector]
    public bool isJumping;
    [HideInInspector]
    public bool grabbingLedge;
    [HideInInspector]
    public bool takingDamage;
    [HideInInspector]
    public bool isDead;
    [HideInInspector]
    public Rigidbody2D playerRB;
    [HideInInspector]
    public Collider2D playerCollider;
    [HideInInspector]
    public Animator playerAnim;
    [HideInInspector]
    public GameObject currentPlatform;
    [HideInInspector]
    private Vector2 facingRight;
    public LayerMask collisionLayer;
    [HideInInspector]
    public MainCharacter mainCharacter;
    void Start()
    {
        Initialization();
    }
    public void Initialization()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerAnim = GetComponent<Animator>();
        mainCharacter = GetComponent<MainCharacter>();
        facingRight = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
    public void Flip()
    {
        if (isFacingRight)
        {
            transform.localScale = facingRight;
        }
        if (!isFacingRight)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
    public bool CollisionCheck(Vector2 direction, float distance, LayerMask collision)
    {
        //Sets up an array of hits so if the player is colliding with multiple objects, it can sort through each one to look for one it should
        RaycastHit2D[] hits = new RaycastHit2D[10];
        //An int to help sort the hits variable so the Character can run a for loop and check the values of each collision
        int numHits = playerCollider.Cast(direction, hits, distance);
        //For loop that sorts hits with the int value it receives based on the Collider2D.Cast() method
        for (int i = 0; i < numHits; i++)
        {
            //If there is at least 1 layer that has been setup by a child script of a layer it should look out for
            if ((1 << hits[i].collider.gameObject.layer & collision) != 0)
            {
                //If the script that is calling this method has a matching layer, then it sets the colliding gameobject as the current platform
                currentPlatform = hits[i].collider.gameObject;
                //Returns this method as true if the above if statement is true
                return true;
            }
        }
        //If the logic makes it to hear, then there aren't any layers that whatever child script called this method should be looking out for and returns false back to that child script
        currentPlatform = null;
        return false;
    }
}
