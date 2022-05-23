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


    void Start()
    {
        movableRb = GetComponent<Rigidbody2D>();
    }


    public bool CheckIfGroundLedge(Transform checker)
    {
        return Physics2D.Raycast(checker.position, Vector2.down, groundLedgeCheckDistance, whatIsGround);
    }







    void Update()
    {
        if (! CheckIfGroundLedge(checkerOne) || ! (CheckIfGroundLedge(checkerTwo)))
        {
            preventFalling.GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (player.CheckIfBlockWillTouch() && ! player.InputHandler.PushInput)
        {
            this.gameObject.transform.SetParent(null);
        }
        else if (player.CheckIfBlockWillTouch())
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            preventFalling.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (player.CheckIfTouchingMovable() && player.InputHandler.PushInput)
        {
            this.gameObject.transform.SetParent(player.gameObject.transform);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            preventFalling.GetComponent<BoxCollider2D>().enabled = false;
        } else if (player.CheckIfTouchingMovable() || ! player.InputHandler.PushInput)
        {
            this.gameObject.transform.SetParent(null);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            preventFalling.GetComponent<BoxCollider2D>().enabled = false;
        }  
    }


}
