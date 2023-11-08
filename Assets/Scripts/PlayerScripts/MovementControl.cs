using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MainCharacter
{
    public float moveSpeed = 100;
    private float distanceToCollider = .08f;
    private float horizontalInput;
    //Total number of jumps allowed
    public int maxJumps = 1;
    //How high the player should go when jump button is pressed
    public float jumpForce = 15f;
    //How long the jump button should be held to perform maximum jump height
    public float maxButtonHoldTime = .4f;
    //How much additional air the player receives when holding the jump button
    public float holdForce = 1;
    //How fast the player can rise while jumping; this prevents multiple jumps in succession from increasing the vertical velocity too much
    public float maxJumpSpeed = 6;
    //How fast the player can fall; this prevents the vertical velocity from decreasing the longer the player falls
    public float maxFallSpeed = -15;
    public float fallSpeed = 3;
    //How much the gravity should be changed for certain things
    public float gravityMultipler = 3;
    //Checks to see if input for the jump is pressed
    private bool jumpPressed;
    //Checks to see if the input for jump is held down
    private bool jumpHeld;
    //How long the jump button has been held
    private float buttonHoldTime;
    //The original gravity value that gravityMultiplier should reset to
    private float originalGravity;
    //The number of jumps the player can perform after the initial jump
    private int numberOfJumpsLeft;
    //Very brief delay so OnCollisionStay2D method can still detect input
    private float inputDelay;
    //A bool that checks to see if the player is currently passing through a one way platform
    [HideInInspector]
    public bool passingThroughPlatform;
    //Checks to see if the Input detects both a downward direction being held down and the jumpHeld button is true at the same time
    [HideInInspector]
    public float jumpDelay;
    public float jumpTime;
    private bool isFalling;
    public bool downJumpPressed;
    private Collider2D nextPlatform;

    void Start()
    {
        Initialization();
        //Sets up the buttonHoldTime to the original max value
        buttonHoldTime = maxButtonHoldTime;
        //Sets the original gravity to whatever gravity settings are setup on the Rigidbody2D
        originalGravity = playerRB.gravityScale;
        //Sets the total number of jumps left to the max value
        numberOfJumpsLeft = maxJumps;
        // Allows movement on load
        mainCharacter.inputEnabled = true;
    }
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 && !mainCharacter.takingDamage && !mainCharacter.grabbingLedge && mainCharacter.inputEnabled == true)
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }
        //If no input or taking damage, horizontalInput = 0
        else
        {
            horizontalInput = 0;
        }
        //Checks to see what buttons are pressed specifically for jump functions
        CheckForInput();
        //Checks to make sure the conditions for a jump are true to allow the FixedUpdate method to calculate jump speeds
        CheckForJump();
        //Checks if the player is grounded
        GroundCheck();
        //Turns collisions back on for one way platforms
    }
    void FixedUpdate()
    {
        Movement();
        SpeedModifier();
        StartCoroutine(IsJumping());
    }
    void Movement()
    {
        //Sets the Rigidbody2D velocity to speed
        playerRB.velocity = new Vector3(horizontalInput * moveSpeed * Time.deltaTime, playerRB.velocity.y);
        //Checks to see if there is movement input for various needed logic
        if (horizontalInput != 0)
        {
            //Stops playing the idle animation
            playerAnim.SetBool("Idle", false);
            //Starts playing the walking animation
            playerAnim.SetBool("Walking", true);
            //Checks to see if the input would move the character rightwards but also checks if the player is facing left
            if (horizontalInput < 0 && mainCharacter.isFacingRight)
            {
                //Sets the isFacingLeft bool to false so the Flip() method can run the appropriate logic
                mainCharacter.isFacingRight = false;
                //Method found in Character script to flip the character as needed
                Flip();
            }
            //Same as above if statement, but if character is moving leftward and is facing right
            if (horizontalInput > 0 && !mainCharacter.isFacingRight)
            {
                //Sets the isFacingLeft bool to true so the Flip() method can run the apprpriate logic
                mainCharacter.isFacingRight = true;
                //Method found in Character script to flip the character as needed
                Flip();
            }
        }
        //If there is no movement input
        else
        {
            //Plays the idle animation
            playerAnim.SetBool("Idle", true);
            //Stops playing the walking animation
            playerAnim.SetBool("Walking", false);
        }
    }
    private void SpeedModifier()
    {
        //Long if statement that checks to see if character is jumping or falling and running into a wall
        if((playerRB.velocity.x > 0 && CollisionCheck(Vector2.right, distanceToCollider, collisionLayer)) 
            || (playerRB.velocity.x < 0 && CollisionCheck(Vector2.left, distanceToCollider, collisionLayer)) 
            && !mainCharacter.isGrounded)
        {
            //If that wall or platform is a one way platform, then do nothing
            if(currentPlatform.GetComponent<OneWayPlatform>() 
                && currentPlatform.GetComponent<OneWayPlatform>().type != OneWayPlatform.OneWayPlatforms.GoingDown)
            {
                return;
            }
            //Sets a very small horizontal velocity value so the player can naturally fall if touching a wall while jumping
            playerRB.velocity = new Vector2(.01f, playerRB.velocity.y);
        }
    }
    private void CheckForInput()
    {
        //Checks if the jump button is pressed
        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }
        else
            jumpPressed = false;
        //Checks if the jump button is held down
        if (Input.GetButton("Jump"))
        {
            jumpHeld = true;
        }
        else
            jumpHeld = false;
        if (Input.GetAxis("Vertical") < 0 && jumpPressed)
        {
            //Resets inputDelay back to 0
            inputDelay = 0;
            downJumpPressed = true;
        }
        else
        {
            //Checks to see if inputDelay is less than .05f
            if(inputDelay < .02f)
            {
                //Adds the amount of time since last frame to the inputDelay value
                inputDelay += Time.deltaTime;
            }
            //If inputDelay is greater than .05f
            if (inputDelay >= .02f)
            {
                downJumpPressed = false;
            }
        }
    }
    private void CheckForJump()
    {
        //Checks if the jump button is pressed and not pressing down
        if (!downJumpPressed && jumpPressed)
        {
            //If the character is not grounded and hasn't performed an initial jump than this is likely because the player stepped off a ledge
            if ((!mainCharacter.isGrounded) && numberOfJumpsLeft == maxJumps)
            {
                //Doesn't allow the jump and returns out of method
                mainCharacter.isJumping = false;
                return;
            }
            //Negates numberOfJumpsLeft by 1
            numberOfJumpsLeft--;
            //If the number of jumps left is not currently negative
            if (numberOfJumpsLeft >= 0)
            {
                //Gives each jump fresh gravity values so each jump will perform the same
                playerRB.gravityScale = originalGravity;
                //Resets velocity for fresh jump
                playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
                //Resets buttonHoldTime back to max value for a fresh jump
                buttonHoldTime = maxButtonHoldTime;
                //Sets isJumping bool found on Character script to true to enter the jumping state
                mainCharacter.isJumping = true;
            }
        }
    }
    private IEnumerator IsJumping()
    {
        //Checks if character is in jump state
        if(mainCharacter.isJumping)
        {
            inputEnabled = false;
            yield return new WaitForSeconds(jumpDelay);
            inputEnabled = true;
            //Applies initial jump force
            playerRB.AddForce(Vector2.up * jumpForce);
            //Checks for additional air if holding down jump button
            AdditionalAir();
            yield return new WaitForSeconds(jumpTime);
            mainCharacter.isJumping = false;
            isFalling = true;
        }
        //Limits jump vertical velocity so multiple jumps performed quickly don't propel the player upwards
        if (playerRB.velocity.y > maxJumpSpeed)
        {
            //Sets the vertical velocity to the jump speed limit
            playerRB.velocity = new Vector2(playerRB.velocity.x, maxJumpSpeed);
        }
        //Handles fall logic
        Falling();
    }
    private void AdditionalAir()
    {
        //Checks if jump button is held down
        if (jumpHeld)
        {
            //Negates the buttonHoldTime value by time
            buttonHoldTime -= Time.deltaTime;
            //If the buttonHoldTime is 0 or less than 0
            if (buttonHoldTime <= 0)
            {
                //Sets the buttonHoldTime to 0
                buttonHoldTime = 0;
                //Gets character out of jumping state
                mainCharacter.isJumping = false;
            }
            //If buttonHoldTime is greater than 0
            else
                //Performs additional jump height by the holdForce value
                playerRB.AddForce(Vector2.up * holdForce);
        }
        //If not holding down the jump button any longer and buttonHOldTime is greater than 0
        else
        {
            //Gets character out of jumping state
            mainCharacter.isJumping = false;
        }
    }
    private void Falling()
    {
        if (isFalling)
        {
            //If character is not currently jumping up and the vertical velocity is officially in the falling state
            if (!mainCharacter.isJumping && playerRB.velocity.y < fallSpeed)
            {
                //Pushes the player down a bit faster to perform a more specific jump often found in platformers and not have such a floaty jump
                playerRB.gravityScale = gravityMultipler;
            }
            //If the vertical velocity is less than the fastest the player should be falling
            if (playerRB.velocity.y < maxFallSpeed)
            {
                //Sets vertical velocity to the maximum speed allowed to fall
                playerRB.velocity = new Vector2(playerRB.velocity.x, maxFallSpeed);
            }
        }
    }
    private void GroundCheck()
    {
        //Method found in the Character script that checks if the player is touching a ground platform and if the character is not in a jumping state
        if (CollisionCheck(Vector2.down, distanceToCollider, collisionLayer) && !mainCharacter.isJumping)
        {
            //Checks to see if either the passingThroughPlatform bool is true or if the nextPlatform Collider2D is not null
            if(passingThroughPlatform)
            {
                //Sets a parameter on Animator component to allow jump and falling based animations to play
                playerAnim.SetBool("Grounded", false);
                //Player is not longer in grounded state
                mainCharacter.isGrounded = false;
            }
            //If CollisionCheck() returns true and the passingThroughPlatform bool is false and nextPlatform Collider2D is null
            else
            {
                //Player enters a grounded state
                mainCharacter.isGrounded = true;
                isFalling = false;
                //Sets the Animator to the Grounded state
                playerAnim.SetBool("Grounded", true);
                //Resest the numberOfJumpsLeft back to max value
                numberOfJumpsLeft = maxJumps;
                //Resets gravity back to original value
                playerRB.gravityScale = originalGravity;
            }
        }
        //If the above if statement returns false, then character is not touching platform or is in a jumping state
        else
        {
            //Sets a parameter on the Animator component to feed the yVelocity value the current Rigidbody2D velocity y value
            playerAnim.SetFloat("yVelocity", playerRB.velocity.y);
            //Sets a parameter on Animator component to allow jump and falling based animations to play
            playerAnim.SetBool("Grounded", false);
            //Player is not longer in grounded state
            mainCharacter.isGrounded = false;
        }
    }
    private void CheckForPlatformBelow() 
    {
        //Performs a raycast to see if a platform layer is beneath the player
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(playerCollider.bounds.center.x, playerCollider.bounds.min.y), Vector2.down, Mathf.Infinity, collisionLayer);
        //Checks to see if the colliding platform beneath the player is a one way platform and allows the player to pass through it based on the one way platform type
        if (hit.collider.GetComponent<OneWayPlatform>()
            && (hit.collider.GetComponent<OneWayPlatform>().type != OneWayPlatform.OneWayPlatforms.GoingUp))
        {
            //Sets the private gameobject passedThroughPlatform to the current raycast hit platform
            nextPlatform = hit.collider;
            //Ignores the current platform that the player should pass through because the player is downward jumping from above the platform
            Physics2D.IgnoreCollision(playerCollider, nextPlatform, false);
        }
    }
    private void DisableMovement(bool MovementIsDisabled)
    {

    }
}
