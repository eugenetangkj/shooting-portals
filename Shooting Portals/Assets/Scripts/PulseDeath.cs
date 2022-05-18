using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        //use animator to delay restarting of level
        playerRb.bodyType = RigidbodyType2D.Static;
        playerAnim.SetTrigger("death");
    }

    private void RestartLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
