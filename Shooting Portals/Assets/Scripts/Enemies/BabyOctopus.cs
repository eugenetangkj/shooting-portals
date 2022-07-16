using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a Baby Octopus instance, which is spawned by the Boss Octopus in Level 10
public class BabyOctopus : MonoBehaviour
{
    #region Baby Octopus Data
    private Player player;

    [SerializeField] private GameObject enemyToDestroy;
    [SerializeField] private DeathLogic deathLogic;
    [SerializeField] private AudioSource hitSound;

    private bool canMove = false;


    public bool shouldReturn;
    private float enemyX;

    private Animator anim;
    private bool isAlive;
    [SerializeField] private bool facingLeft;


    private Vector3 enemyOriginalPos;
    [SerializeField] private float speed = 0.5f;

    #endregion

    #region Main Methods
    
    private void Start()
    {
        enemyOriginalPos = transform.position;
        anim = this.GetComponent<Animator>();
        shouldReturn = false;
        isAlive = true;
        enemyX = this.transform.position.x;
        Invoke("changeCanMove", 3f);
    }

    
    private void Update()
    {
        if (isAlive && canMove)
        {
            if (transform.position == enemyOriginalPos)
            {
                if (facingLeft)
                {
                    transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                }
                else {
                    transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
                }

            }

            enemyX = this.transform.position.x;

            
            //Move towards player position
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);

            if (transform.position.x > enemyX)
            {
                //Moving towards the right
                transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
            }
            else if (transform.position.x < enemyX)
            {
                //Moving towards the left
                transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            }
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack Bullet")
        {
            isAlive = false;
            enemyToDestroy.GetComponent<Animator>().SetTrigger("destroy");
            this.hitSound.Play();
            this.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(deathLogic);
            Invoke("DestroyEnemy", 1.2f);
        } else if (collision.tag == "Player")
        {
            player.StateMachine.ChangeState(player.DeathState);
        }
    }

    #endregion

    #region Baby Octopus Methods

    private void DestroyEnemy()
    {
        Destroy(enemyToDestroy);
    }

    private void changeCanMove()
    {
        canMove = true;
    }

    public void setPlayer(Player playerToAssign)
    {
        player = playerToAssign;
    }

    #endregion
}

