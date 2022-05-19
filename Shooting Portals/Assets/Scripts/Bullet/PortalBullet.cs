using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    private Rigidbody2D rb;
    private Animator anim;
    private float bulletLifeSpan = 0.5f;
    private float bulletSpawnTime;
    
    void Start()
    {
        bulletSpawnTime = Time.time;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.velocity = transform.right * bulletSpeed;
    }

    void Update()
    {
        checkBulletExpiry();
    }

    void OnTriggerEnter2D(Collider2D objectHit)
    {
        anim.SetBool("hit", true);
        rb.velocity = Vector2.zero;
        Invoke("DestroyBullet", 0.5f); //Destroys the bullet on contact
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    void checkBulletExpiry()
    {
        if (Time.time > bulletSpawnTime + bulletLifeSpan)
        {
            anim.SetBool("hit", true);
            rb.velocity = Vector2.zero;
            Invoke("DestroyBullet", 0.5f); //Destroys the bullet on contact
        }
    }
    
}
