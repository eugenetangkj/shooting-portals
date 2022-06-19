using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFallingPlatform : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] FallingBrick platform;
    [SerializeField] GameObject detector;
    
    [SerializeField] AudioSource platformFallSound;
    [SerializeField] float restoreDuration;
    [SerializeField] float inAirDuration;


    private bool canToggle = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && canToggle)
        {
            platform.GetComponent<Animator>().SetBool("shake", true);
            Invoke("makePlatformFall", inAirDuration);
            Invoke("restorePlatform", restoreDuration);    
        }
    }


    private void makePlatformFall()
    {
        platformFallSound.Play();
        platform.GetComponent<Animator>().SetBool("shake", false);
        platform.GetComponent<BoxCollider2D>().enabled = false;
        detector.GetComponent<BoxCollider2D>().enabled = false;
        platform.fall();
    }

    private void restorePlatform()
    {
        platform.restore();
        platform.GetComponent<BoxCollider2D>().enabled = true;
        canToggle = true;
    }



    
}
