using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseMovement : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float moveSpeed = 4.5f;
    Rigidbody2D playerRb;
    private enum MovementState {idle, run, jump};
    private Animator playerAnim;
    private float dirX;
    private SpriteRenderer playerSprite;
    private MovementState state = MovementState.idle;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        playerAnim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        playerRb.velocity = new Vector2(dirX * moveSpeed, playerRb.velocity.y);
        
        //Jump logic
        if (Input.GetButtonDown("Jump") && isGrounded()) 
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState () 
    {
        
        if (playerRb.velocity.y > 0.1f) {
            state = MovementState.jump;
        }
        else if (playerRb.velocity.x > 0) {
            playerSprite.flipX = false;
            state = MovementState.run;
        }
        else if (playerRb.velocity.x < 0) {
            playerSprite.flipX = true;
            state = MovementState.run;
        }

        playerAnim.SetInteger("state", (int) state);
    }

    private bool isGrounded() 
    {
        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    
}
