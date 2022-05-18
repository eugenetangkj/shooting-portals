using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseDeath : MonoBehaviour
{
    private Animator playerAnim;
    private Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D (Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("OutOfMap")) 
        {
            Die();
        }
    }

    private void Die () 
    {
        //switch to death animation
        playerRb.bodyType = RigidbodyType2D.Static;
    }
}
