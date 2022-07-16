using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents an enemy that moves in a predictable manner.
public class EnemyMoving : MonoBehaviour
{
    #region Enemy Data
    [SerializeField] private GameObject enemyToDestroy;
    [SerializeField] private DeathLogic deathLogic;
    [SerializeField] private WaypointFollowerEnemy waypointEnemy;
    [SerializeField] private AudioSource hitSound;
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroys the enemies if an attack bullet hits the moving enemy
        if (collision.tag == "Attack Bullet")
        {
           enemyToDestroy.GetComponent<Animator>().SetTrigger("destroy");
           this.hitSound.Play();
           this.GetComponent<BoxCollider2D>().enabled = false;
           Destroy(deathLogic);
           Destroy(waypointEnemy);
           Invoke("DestroyEnemy", 1.2f);
        }
    }

    //Destroys the enemy
    private void DestroyEnemy()
    {
        Destroy(enemyToDestroy);
    }
}

