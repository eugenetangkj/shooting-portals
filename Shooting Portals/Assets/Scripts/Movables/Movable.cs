using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    Rigidbody2D movableRb;
    [SerializeField] Player player;


    void Start()
    {
        movableRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player.CheckIfBlockWillTouch())
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (player.CheckIfTouchingMovable() && player.InputHandler.PushInput)
        {
            this.gameObject.transform.SetParent(player.gameObject.transform);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        } else if (player.CheckIfTouchingMovable() || ! player.InputHandler.PushInput)
        {
            this.gameObject.transform.SetParent(null);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;

        }


    }

}
