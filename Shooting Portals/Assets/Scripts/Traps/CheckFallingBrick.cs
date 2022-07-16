using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class handles the logic of making the block traps fall and spawn in Level 2
public class CheckFallingBrick : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] FallingBrick brickOne;
    [SerializeField] FallingBrick brickTwo;
    [SerializeField] GameObject timer;
    [SerializeField] AudioSource brickFallSound;
    [SerializeField] float fallDuration;

    private bool shouldFall = false;
    private bool canToggle = true;

    private void Update()
    {
        shouldFall = Physics2D.OverlapCircle(this.transform.position, 2f, playerLayer); //Checks if player enters the vicinity and that the blocks should be present in their original positions
        if (shouldFall && canToggle)
        {
            canToggle = false;
            timer.GetComponent<Animator>().SetBool("appear", true);
            Invoke("makeBricksFall", 5f);
            Invoke("restoreBricks", fallDuration);
        } 
    }

    //Make both bricks fall downwards
    private void makeBricksFall()
    {
        brickFallSound.Play();
        brickOne.fall();
        brickTwo.fall();
        timer.GetComponent<Animator>().SetBool("appear", false);
    }

    //Restores both bricks to original positions
    private void restoreBricks()
    {
        brickOne.restore();
        brickTwo.restore();
        canToggle = true;
    }
}
