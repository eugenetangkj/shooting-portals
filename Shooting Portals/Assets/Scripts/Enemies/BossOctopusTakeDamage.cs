using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOctopusTakeDamage : MonoBehaviour
{
    [SerializeField] private BossOctopus bossOctopus;
    [SerializeField] private AudioSource audioEffect;
    [SerializeField] private int targetNumber;

    private Animator anim;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack Bullet")
        {
            bossOctopus.setTargetSpawnArea(targetNumber);
            bossOctopus.doDamage();
            bossOctopus.increaseHit();
            audioEffect.Play();
            anim.SetBool("hit", true);
        }
    }

    private void Start()
    {
        anim = bossOctopus.GetComponent<Animator>();
    }
}
