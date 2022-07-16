using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class handles the logic for shaky platforms
public class CheckFallingPlatform : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] FallingBrick platform;
    [SerializeField] GameObject detector;
    
    [SerializeField] AudioSource platformFallSound;
    [SerializeField] float restoreDuration; //Time between spawning of shaky platforms
    [SerializeField] float inAirDuration; //Time that shaky platform will shake before dropping


    private bool canToggle = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && canToggle)
        {
            platform.GetComponent<Animator>().SetBool("shake", true);
            Invoke("makePlatformFall", inAirDuration);
            Invoke("restorePlatform", restoreDuration);
            canToggle = false;    
        }
    }


    //Make shaky platform fall
    private void makePlatformFall()
    {
        platformFallSound.Play();
        platform.GetComponent<Animator>().SetBool("shake", false);
        platform.GetComponent<BoxCollider2D>().enabled = false;
        detector.GetComponent<BoxCollider2D>().enabled = false;
        platform.fall();
    }

    //Restores shaky platform to its original position
    private void restorePlatform()
    {
        platform.restore();
        platform.GetComponent<BoxCollider2D>().enabled = true;
        detector.GetComponent<BoxCollider2D>().enabled = true;
        canToggle = true;
    }



    
}
