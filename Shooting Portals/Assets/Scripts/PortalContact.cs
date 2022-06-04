using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalContact : MonoBehaviour
{
    //Player's components
    private Rigidbody2D playerRb;
    private Animator playerAnim;

    [SerializeField] GameObject background;
    [SerializeField] GameObject canvas;

    private bool inContact = false;
    private bool hasTeleported = false;

    //Up Arrow Key instance
    [SerializeField] GameObject key;

    private void Start() {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    private void Update() {
        if (inContact && Input.GetKeyDown(KeyCode.UpArrow) && ! hasTeleported) {
            playerAnim.SetTrigger("disappear");
            background.GetComponent<Animator>().SetTrigger("appear");
            canvas.GetComponent<Animator>().SetTrigger("appear");
            hasTeleported = true;
            Invoke("nextLevel", 3.9f);
        }
    }

    //Checks if player comes in contact with a portal.
    //If so, play the up arrow key animation.
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Portal")) {
            key.GetComponent<Animator>().SetBool("play", true);
            inContact = true;

        }
    }

    //Checks if player is no longer in contact with a portal.
    // If so, stop playing the up arrow key animation.
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Portal")) {
            key.GetComponent<Animator>().SetBool("play", false);
            inContact = false;
        }
    }

    private void nextLevel()
    {
        SceneManager.LoadScene("Loading Screen Portal");
    }
}
