using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAILeftRight : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private GameObject enemyToDestroy;
    [SerializeField] private DeathLogic deathLogic;
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private GameObject slimeDetector;


    public bool shouldReturn;

    private float enemyX;
    private Animator anim;
    private bool isAlive;


    private Vector3 enemyOriginalPos;
    [SerializeField] private float speed = 0.5f;

    // Update is called once per frame
    
    private void Start()
    {
        enemyOriginalPos = transform.position;
        enemyX = transform.position.x;
        anim = this.GetComponent<Animator>();
        shouldReturn = false;
        isAlive = true;
    }

    
    private void Update()
    {
        if (isAlive)
        {
            if (transform.position == enemyOriginalPos)
            {
                anim.SetBool("move", false);
                transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

            }
            else
            {
            anim.SetBool("move", true);
            }

            enemyX = transform.position.x;

            if (shouldReturn)
            {
                transform.position = Vector2.MoveTowards(transform.position, enemyOriginalPos, Time.deltaTime * speed);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, enemyOriginalPos.y), Time.deltaTime * speed);
            }

            if (transform.position.x >= enemyX)
            {
                //Moving towards the right
                transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            }
            else 
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
            Destroy(slimeDetector);
            Invoke("DestroyEnemy", 1.2f);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(enemyToDestroy);
    }
}
