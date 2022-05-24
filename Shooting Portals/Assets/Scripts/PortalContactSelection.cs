using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalContactSelection : MonoBehaviour
{
    //Player's components
    private Rigidbody2D playerRb;
    private Animator playerAnim;

    // [SerializeField] GameObject background;
    // [SerializeField] GameObject canvas;

    private static bool inContact = false;

    //Instructions to appear
    [SerializeField] GameObject key;

    private void Start() {
        inContact = false;
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

  
    //Checks if player comes in contact with a portal.
    //If so, play the up arrow key animation.
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Portal")) {
            key.GetComponent<Animator>().SetBool("play", true);
            PortalContactSelection.inContact = true;

        }
    }

    //Checks if player is no longer in contact with a portal.
    // If so, stop playing the up arrow key animation.
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Portal")) {
            key.GetComponent<Animator>().SetBool("play", false);
            PortalContactSelection.inContact = false;
        }
    }

    public static bool checkContact()
    {
        return PortalContactSelection.inContact;
    }
}
