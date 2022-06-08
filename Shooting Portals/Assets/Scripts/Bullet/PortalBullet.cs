using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] GameObject portalPrefab;
    private Rigidbody2D rb;
    private Animator anim;
    private float bulletLifeSpan = 0.5f;
    private float bulletSpawnTime;
    private float count = 0;

    private Vector2 portalPos;
    private float portalYoffset = 0.6f;

    
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
        if (objectHit.tag == "Portal Breaker")
        {
            anim.SetBool("hit", true);
            rb.velocity = Vector2.zero;
            
            Invoke("DestroyBullet", 0.5f);
        }

        else if (objectHit.tag == "Movables")
        {
           if (count == 0)
            {
                Debug.Log("reached");
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
