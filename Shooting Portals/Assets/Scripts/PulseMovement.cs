using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseMovement : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float jumpForce = 7f;
    Rigidbody2D playerRb;
    private enum MovementState {idle, run, jump};
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jump logic
        
        if (Input.GetButtonDown("Jump") && isGrounded()) 
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState () 
    {
        MovementState state = MovementState.idle;
        if (playerRb.velocity.y > 0.1f) {
            state = MovementState.jump;
        }

        playerAnim.SetInteger("state", (int) state);
    }

    private bool isGrounded() 
    {
        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    
}