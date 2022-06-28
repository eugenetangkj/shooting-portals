using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWithBlock : MonoBehaviour
{
    [SerializeField] private GameObject enemyToDestroy;
    [SerializeField] private DeathLogic deathLogic;
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private GameObject target;

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

    private void DestroyEnemy()
    {
        Destroy(enemyToDestroy);
    }
}