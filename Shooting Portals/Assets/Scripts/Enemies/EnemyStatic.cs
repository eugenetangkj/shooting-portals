using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a static enemy
public class EnemyStatic : MonoBehaviour
{
    #region Enemy Data
    [SerializeField] private GameObject enemyToDestroy;
    [SerializeField] private DeathLogic deathLogic;
    [SerializeField] private AudioSource hitSound;
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroys the enemy if an attack bullet hits the static enemy
        if (collision.tag == "Attack Bullet")
        {
           enemyToDestroy.GetComponent<Animator>().SetTrigger("destroy"); 
           hitSound.Play();
           this.GetComponent<BoxCollider2D>().enabled = false;
           Destroy(deathLogic);
           Invoke("DestroyEnemy", 1.2f);
        }
    }

    //Destroys the enemy
    private void DestroyEnemy()
    {
        Destroy(enemyToDestroy);
    }
}
