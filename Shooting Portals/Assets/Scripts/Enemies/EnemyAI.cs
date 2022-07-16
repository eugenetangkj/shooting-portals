using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents an Enemy AI that will move both horizontally and vertically towards the player if the player
//enter its vicinity.
public class EnemyAI : MonoBehaviour
{
    #region EnemyAI Data
    [SerializeField] private Player player;

    [SerializeField] private GameObject enemyToDestroy;
    [SerializeField] private DeathLogic deathLogic;
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private GameObject eyeballDetector;


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
        shouldReturn = true;
        isAlive = true;
        enemyX = this.transform.position.x;
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
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
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

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack Bullet")
        {
            isAlive = false;
            enemyToDestroy.GetComponent<Animator>().SetTrigger("destroy");
            this.hitSound.Play();
            this.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(deathLogic);
            Destroy(eyeballDetector);
            Invoke("DestroyEnemy", 1.2f);
        }
    }

    #endregion

    #region Enemy AI Methods
    //Destroys the enemy AI
    private void DestroyEnemy()
    {
        Destroy(enemyToDestroy);
    }
    #endregion
}
