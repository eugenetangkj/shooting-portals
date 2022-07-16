using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This class represents an enemy AI that will move towards the player in both vertical and horizontal axes if the player
   enters its vicinity, but it does so in a delayed manner. Player's position is only fed to this enemy AI every few seconds,
   instead of every frame. */
public class EnemyAIDelayed : MonoBehaviour
{
    #region EnemyAIDelayed Data
    [SerializeField] private Player player;

    private Vector2 playerPos;

    private float enemyX;

    private bool isAlive;
    [SerializeField] private bool facingLeft;
    public bool shouldReturn;


    private Vector3 enemyOriginalPos;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float delay = 5f;

    #endregion

    #region Main Methods
    private void Start()
    {
        enemyOriginalPos = transform.position;
        shouldReturn = true;
        isAlive = true;
        enemyX = this.transform.position.x;
        InvokeRepeating("trackPlayer", 0.01f, delay);
    }

 



    private void Update()
    {
        if (isAlive)
        {
            if (transform.position == enemyOriginalPos)
            {
                if (facingLeft)
                {
                    transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
                }
                else {
                    transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                }

            }

            enemyX = this.transform.position.x;

            if (shouldReturn)
            {
                //Move towards original position
                transform.position = Vector2.MoveTowards(transform.position, enemyOriginalPos, Time.deltaTime * speed);
            }
            else
            {
                //Move towards player position
                transform.position = Vector2.MoveTowards(transform.position, playerPos, Time.deltaTime * speed);
            }

            if (transform.position.x > enemyX)
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

    #endregion

    #region EnemyAIDelayed Methods

    //Supplies the player's current position to the enemy AI, but it is only called every few seconds
    private void trackPlayer()
    {
        playerPos = player.transform.position;
    }

    #endregion

}
