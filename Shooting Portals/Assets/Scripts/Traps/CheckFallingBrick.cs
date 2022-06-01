using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFallingBrick : MonoBehaviour
{
    [SerializeField] FallingBrick brickOne;
    [SerializeField] FallingBrick brickTwo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //TODO: Start countdown
            Invoke("makeBricksFall", 5f);
            Invoke("restoreBricks", 9f);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //TODO: Reset countdown
            restoreBricks();
        }
    }





    private void makeBricksFall()
    {
        brickOne.fall();
        brickTwo.fall();
    }

    private void restoreBricks()
    {
        brickOne.restore();
        brickTwo.restore();
    }
}
