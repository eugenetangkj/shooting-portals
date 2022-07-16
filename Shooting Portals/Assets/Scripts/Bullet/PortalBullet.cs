using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a Portal Bullet instance, which will be instantiated whenever Pulse shoots, or presses V.
public class PortalBullet : MonoBehaviour
{
    #region Portal Bullet Data
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] GameObject portalPrefab;
    private Rigidbody2D rb;
    private Animator anim;
    private float bulletLifeSpan = 0.5f;
    private float bulletSpawnTime;
    private float count = 0;

    private Vector2 portalPos;
    private float portalYoffset = 0.6f;

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
        if (objectHit.tag == "Portal Breaker" || objectHit.tag == "Movables" || objectHit.tag == "Sensor" || objectHit.tag == "Shaky Platforms" || objectHit.tag == "Player Sensor")
        {
            anim.SetBool("hit", true);
            rb.velocity = Vector2.zero;
            // this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Invoke("DestroyBullet", 0.5f);
        }
        else
        {
            if (objectHit.tag == "Moving Platforms")
            {
                if (count == 0)
                {
                    Player.updateShootDirection();
                    portalPos.Set(transform.position.x, transform.position.y + portalYoffset);
                    Portal portalToCreate = Instantiate(portalPrefab, portalPos, transform.rotation).GetComponent<Portal>();
                    Portal.createPortal(portalToCreate);
                    portalToCreate.transform.SetParent(objectHit.transform);
                    count = count + 1;
                }
                anim.SetBool("hit", true);
                rb.velocity = Vector2.zero;
                Invoke("DestroyBullet", 0.5f); //Destroys the bullet on contact
            }
            else if (objectHit.tag != "Portal")
            {
                if (count == 0)
                {
                    Player.updateShootDirection();
                    portalPos.Set(transform.position.x, transform.position.y + portalYoffset);
                    Portal portalToCreate = Instantiate(portalPrefab, portalPos, transform.rotation).GetComponent<Portal>();
                    Portal.createPortal(portalToCreate);
                    count = count + 1;
                }
                anim.SetBool("hit", true);
                rb.velocity = Vector2.zero;
                Invoke("DestroyBullet", 0.5f); //Destroys the bullet on contact
            }
        }
    }

    #endregion

    #region Portal Bullet Methods
    //Destroys the portal bullet instance
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    //Checks if the portal bullet instance is alive for longer than it should have been. If so, it calls DestroyBullet to destroy it.
    private void checkBulletExpiry()
    {
        if (Time.time > bulletSpawnTime + bulletLifeSpan)
        {
            anim.SetBool("hit", true);
            rb.velocity = Vector2.zero;
            Invoke("DestroyBullet", 0.5f); //Destroys the bullet on contact
        }
    }
    
    #endregion
    
}
