using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This class represents an Attack Bullet object, which is instantiated whenever Pulse shoots, or presses C. */
public class AttackBullet : MonoBehaviour
{
    #region Attack Bullet Data
    [SerializeField] float bulletSpeed = 20f;
    private Rigidbody2D rb;
    private Animator anim;
    private float bulletLifeSpan = 0.4f;
    private float bulletSpawnTime;

    #endregion
    
    #region Main Methods
    private void Start()
    {
        bulletSpawnTime = Time.time;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.velocity = transform.right * bulletSpeed;
    }

    private void Update()
    {
        checkBulletExpiry();
    }

    private void OnTriggerEnter2D(Collider2D objectHit)
    {
        anim.SetBool("hit", true);
        rb.velocity = Vector2.zero;
        Invoke("DestroyBullet", 0.4f); //Destroys the bullet on contact
    }

    #endregion

    #region Attack Bullet Methods

    //Destroys the attack bullet instance
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }




    //Checks if an attack bullet is alive for longer than it should have been. If so, it will call DestroyBullet() which will destroy the attack bullet instance
    private void checkBulletExpiry()
    {
        if (Time.time > bulletSpawnTime + bulletLifeSpan)
        {
            anim.SetBool("hit", true);
            rb.velocity = Vector2.zero;
            Invoke("DestroyBullet", 0.4f); //Destroys the bullet on contact
        }
    }

    #endregion
    
}
