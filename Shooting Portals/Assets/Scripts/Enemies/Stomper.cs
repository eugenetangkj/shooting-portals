using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{
    [SerializeField] private float headStart;
    [SerializeField] private float stomperHorizontalVelocity;
    [SerializeField] private Player player;
    private Rigidbody2D rb;
    private bool canMove;
    private float enemyOriginalYPos;

    private void Start()
    {
        Invoke("startRunning", headStart);
        rb = this.GetComponent<Rigidbody2D>();
        canMove = false;
        enemyOriginalYPos = this.transform.position.y;
        
    }

    // Update is called once per frame
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

    private void startRunning()
    {
        canMove = true;
    }

    public void stopRunning()
    {
        rb.velocity = new Vector2(0f, 0f);
        canMove = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            stopRunning();
        }
    }


}
