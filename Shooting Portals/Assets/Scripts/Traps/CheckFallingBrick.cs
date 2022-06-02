using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFallingBrick : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] FallingBrick brickOne;
    [SerializeField] FallingBrick brickTwo;
    [SerializeField] GameObject timer;
    [SerializeField] AudioSource brickFallSound;

    private bool shouldFall = false;
    private bool canToggle = true;

    private void Update()
    {
        shouldFall = Physics2D.OverlapCircle(this.transform.position, 2f, playerLayer);
        if (shouldFall && canToggle)
        {
            canToggle = false;
            timer.GetComponent<Animator>().SetBool("appear", true);
            Invoke("makeBricksFall", 5f);
            Invoke("restoreBricks", 9f);
        } 
    }


    private void makeBricksFall()
    {
        brickFallSound.Play();
        brickOne.fall();
        brickTwo.fall();
        timer.GetComponent<Animator>().SetBool("appear", false);
    }

    private void restoreBricks()
    {
        brickOne.restore();
        brickTwo.restore();
        canToggle = true;
    }
}
