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
            if (! CheckIfGroundLedge(checkerOne) || ! (CheckIfGroundLedge(checkerTwo)))
            {
                preventFalling.GetComponent<BoxCollider2D>().enabled = true;
                //Debug.Log("reached1");
            }
            else if (isTouchingWall && ! player.InputHandler.PushInput)
            {
            this.gameObject.transform.SetParent(null); 
            //Debug.Log("reached2");
            }
            else if (isTouchingWall)
            {
                this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                preventFalling.GetComponent<BoxCollider2D>().enabled = false;
                //Debug.Log("reached3");
            }
            else if (player.CheckIfTouchingMovable() && player.InputHandler.PushInput)
            {
                this.gameObject.transform.SetParent(player.gameObject.transform);
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                preventFalling.GetComponent<BoxCollider2D>().enabled = false;
                //Debug.Log("reached4");
            } else if (player.CheckIfTouchingMovable() || ! player.InputHandler.PushInput)
            {
                this.gameObject.transform.SetParent(null);
                this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                preventFalling.GetComponent<BoxCollider2D>().enabled = false;
                //Debug.Log("reached5");
            }
        }
    }
}
