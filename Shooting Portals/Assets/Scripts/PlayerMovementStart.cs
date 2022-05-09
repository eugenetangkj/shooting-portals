using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is for limited player movement: moving left/right and jump
public class PlayerMovementStart : MonoBehaviour
{
    //Player's components
    private Rigidbody2D playerRb;
    private Animator playerAnim;
    private BoxCollider2D playerCollider;


    //Movement variables
    private float amountToMoveHorizontal = 0f;
    private float moveSpeed = 5f;
    private enum MovementState {idle, run, jump};
    private float jumpForce = 5f;

    //Whether player is facing left or right
    private bool isLeft = false;
    private bool isRight = true;

    //For ground check
    [SerializeField] private LayerMask jumpableGround;



    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        playerAnim = GetComponent<Animator>();
    }


    private void Update()
    {
        /* In Project Settings, "Horizontal" is set to be affected by the left and right arrow keys.
           The more you press left, the more negative it gets.
           The more you press right, the more positive it gets.
        */    
        amountToMoveHorizontal = Input.GetAxisRaw("Horizontal");
        playerRb.velocity = new Vector2(amountToMoveHorizontal * moveSpeed, playerRb.velocity.y);
        
        //Jump logic
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        //Idle and running logic
        if (amountToMoveHorizontal < 0f) //Want to move left
        {
            state = MovementState.run;
            if (isLeft == false)
            {
                //Currently facing right, so need to rotate
                transform.Rotate(0f, 180f, 0f);
                isLeft = true;
                isRight = false;
            }
        }
        else if (amountToMoveHorizontal> 0f) //Want to move right
        {
            state = MovementState.run;
            if (isRight == false)
            {   //Currently facing left, so need to rotate
                transform.Rotate(0f, 180f, 0f);
                isRight = true;
                isLeft = false;
            }
        } else
        {
            state = MovementState.idle;
        }

        //Jump logic
        if (playerRb.velocity.y > 0.1f)
        {
            //Not exactly 0 when player is not moving. Hence, we take a very small value
            //like 0.1f, so if the y-velocity > 0.1f, means user is jumping.
            state = MovementState.jump;
        }
    

        //Sets the corresponding animation
        playerAnim.SetInteger("state", (int) state);
    }

    //Checks if player is in contact with ground.
    private bool IsGrounded()
    {
        //BoxCast is the method that creates the imaginary box around the player.
        //Checks for overlap with jumpableGround. Returns true if there is overlap.
        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    //Prevents player from moving left/right during player entrance animation.
    private void freezePositionX()
    {
        playerRb.constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    //Allows player to move left/right again after play entrance animation.
    private void unfreezePositionsX()
    {
        playerRb.constraints = RigidbodyConstraints2D.None;
    }

}
