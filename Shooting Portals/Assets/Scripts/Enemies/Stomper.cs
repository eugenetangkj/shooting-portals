using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a Stomper, which is the boss in Level 8
public class Stomper : MonoBehaviour
{
    #region Stomper Data
    [SerializeField] private float headStart;
    [SerializeField] private float stomperHorizontalVelocity;
    [SerializeField] private Player player;
    private Rigidbody2D rb;
    private bool canMove;
    private float enemyOriginalYPos;
    #endregion

    #region Main Methods
    private void Start()
    {
        Invoke("startRunning", headStart);
        rb = this.GetComponent<Rigidbody2D>();
        canMove = false;
        enemyOriginalYPos = this.transform.position.y;
        
    }

    private void Update()
    {
        if (canMove)
        {
            float enemyX = transform.position.x;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, enemyOriginalYPos), Time.deltaTime * stomperHorizontalVelocity);
            if (transform.position.x > enemyX )
            {
                //Moving towards the right
                transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            }
            else if (transform.position.x < enemyX) 
            {
                //Moving towards the left
                transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
            }   
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            stopRunning();
        }
    }
    #endregion

    #region Stomper Methods

    //Make stomper start running
    private void startRunning()
    {
        canMove = true;
    }

    //Make stomper stop running
    public void stopRunning()
    {
        rb.velocity = new Vector2(0f, 0f);
        canMove = false;
    }

    #endregion
}
