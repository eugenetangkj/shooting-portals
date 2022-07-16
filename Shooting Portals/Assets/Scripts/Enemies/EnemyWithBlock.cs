using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a static enemy with a vital point.
public class EnemyWithBlock : MonoBehaviour
{
    #region Enemy Data
    [SerializeField] private GameObject enemyToDestroy;
    [SerializeField] private DeathLogic deathLogic;
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private GameObject target;
    #endregion
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack Bullet")
        {
            target.SetActive(false);
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
