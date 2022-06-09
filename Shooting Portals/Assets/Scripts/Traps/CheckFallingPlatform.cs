using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFallingPlatform : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] FallingBrick platform;
    
    //[SerializeField] AudioSource platformFallSound;
    [SerializeField] float fallDuration;


    private bool canToggle = true;

    private Portal portalToDestroy;

    private Transform[] childrenTransforms;

    private int numberOfPortalsToDestroy;

    private void Update()
    {
        childrenTransforms = platform.GetComponentsInChildren<Transform>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && canToggle)
        {
            platform.GetComponent<Animator>().SetBool("shake", true);
            Invoke("makePlatformFall", 1f);
            Invoke("restorePlatform", fallDuration);    
        }
    }


    private void makePlatformFall()
    {
        //platformFallSound.Play(); Play platform fall sound
        platform.GetComponent<Animator>().SetBool("shake", false);
        platform.GetComponent<BoxCollider2D>().enabled = false;
        platform.fall();
        foreach(Transform transformChild in childrenTransforms)
        {
            if (transformChild.GetComponent<Portal>() != null)
            {
                numberOfPortalsToDestroy += 1;
                Portal.destroyOnePortal(transformChild.GetComponent<Portal>());
            }
        }
        Invoke("checkPortals", 2f);
    }

    private void restorePlatform()
    {
        numberOfPortalsToDestroy = 0;
        platform.restore();
        platform.GetComponent<BoxCollider2D>().enabled = true;
        
        canToggle = true;
    }

    private void checkPortals()
    {
        Portal.updatePortalArray(numberOfPortalsToDestroy);
    }



    
}
