using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    Rigidbody2D movableRb;
    [SerializeField] Player player;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] float groundLedgeCheckDistance;
    [SerializeField] Transform checkerOne;
    [SerializeField] Transform checkerTwo;
    [SerializeField] GameObject preventFalling;

    //Fixes
    [SerializeField] GameObject preventPushingOne;
    [SerializeField] GameObject preventPushingTwo;

    bool isTouchingWall;

    void Start()
    {
        movableRb = GetComponent<Rigidbody2D>();
        isTouchingWall = false;
    }


    public bool CheckIfGroundLedge(Transform checker)
    {
        return Physics2D.Raycast(checker.position, Vector2.down, groundLedgeCheckDistance, whatIsGround);
    }









    void Update()
    {
        
        if (player.CheckWhichBlockWillTouch().transform == this.gameObject.transform)
        {
            
            isTouchingWall = player.CheckIfBlockWillTouch();

            if (! player.isInPushState && ! player.InputHandler.PushInput)
            {
                this.gameObject.transform.SetParent(null);
            }
            else if (! CheckIfGroundLedge(checkerOne) || ! (CheckIfGroundLedge(checkerTwo)))
            {
                preventFalling.GetComponent<BoxCollider2D>().enabled = true;
                if (player.FacingDirection == 1)
                {
                    preventPushingOne.GetComponent<BoxCollider2D>().enabled = true;
                } else {
                    preventPushingTwo.GetComponent<BoxCollider2D>().enabled = true;
                }
            }
            else if (isTouchingWall && ! player.InputHandler.PushInput)
            {
                this.gameObject.transform.SetParent(null); 

            }
            
            else if (isTouchingWall)
            {
                this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                Debug.Log(player.FacingDirection);
                if (player.FacingDirection == 1)
                {
                    preventPushingOne.GetComponent<BoxCollider2D>().enabled = true;
                } else {
                    preventPushingTwo.GetComponent<BoxCollider2D>().enabled = true;
                }
                preventFalling.GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (player.CheckIfTouchingMovable() && player.InputHandler.PushInput)
            {
                this.gameObject.transform.SetParent(player.gameObject.transform);
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                preventPushingTwo.GetComponent<BoxCollider2D>().enabled = false;
                preventPushingOne.GetComponent<BoxCollider2D>().enabled = false;
                preventFalling.GetComponent<BoxCollider2D>().enabled = false;
            } else if (player.CheckIfTouchingMovable() || ! player.InputHandler.PushInput)
            {
                this.gameObject.transform.SetParent(null);
                this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                preventFalling.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
