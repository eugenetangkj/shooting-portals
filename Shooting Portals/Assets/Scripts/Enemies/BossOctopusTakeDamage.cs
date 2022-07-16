using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a vital point of the Boss Octopus in Level 10, allowing it to take damage from the player
public class BossOctopusTakeDamage : MonoBehaviour
{
    #region VitalPoint Data
    [SerializeField] private BossOctopus bossOctopus;
    //[SerializeField] private AudioSource audioEffect;
    [SerializeField] private int targetNumber;

    private Animator anim;
    #endregion
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack Bullet")
        {
            bossOctopus.setTargetSpawnArea(targetNumber);
            bossOctopus.doDamage();
            bossOctopus.increaseHit();
            //audioEffect.Play();
            anim.SetBool("hit", true);
        }
    }

    private void Start()
    {
        anim = bossOctopus.GetComponent<Animator>();
    }
}
