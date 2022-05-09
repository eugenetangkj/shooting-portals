using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalContact : MonoBehaviour
{
    //Player's components
    private Rigidbody2D playerRb;
    private Animator playerAnim;

    //Up Arrow Key instance
    [SerializeField] GameObject upArrowKey;

    void Start() {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }
        
    //Checks if player comes in contact with a portal.
    //If so, play the up arrow key animation.
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Portal")) {
            upArrowKey.GetComponent<Animator>().SetBool("play", true);
        }
    }

    //Checks if player is no longer in contact with a portal.
    // If so, stop playing the up arrow key animation.
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Portal")) {
            upArrowKey.GetComponent<Animator>().SetBool("play", false);
        }
    }
}
