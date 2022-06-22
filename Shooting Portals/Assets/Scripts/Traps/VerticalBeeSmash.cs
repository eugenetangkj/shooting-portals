using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBeeSmash : MonoBehaviour
{
    private Vector2 originalPos;
    private bool shouldReset;
    private bool hasTouched;
    private bool isAttached;
    [SerializeField] private float beeVerticalSpeed = 4f;
    [SerializeField] private float beeStartTime = 1f;
    [SerializeField] private float beeTravelDuration = 8f;

    void Start()
    {
        originalPos = this.transform.position;
        shouldReset = true;
        hasTouched = false;
        isAttached = false;
        InvokeRepeating("toggleShouldReset", beeStartTime, beeTravelDuration);
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldReset)
        {
            this.gameObject.transform.SetParent(null);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            this.transform.position = originalPos;
            hasTouched = false;
            isAttached = false;
        }
        else if (! shouldReset && ! hasTouched)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, - beeVerticalSpeed);
        }
    }

    private void toggleShouldReset()
    {
        shouldReset = (shouldReset) ? false : true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Moving Platforms" && ! isAttached)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            hasTouched = true;
            this.gameObject.transform.SetParent(collision.gameObject.transform);
            isAttached = true;

        }
        else if ((collision.tag != "Portal" && collision.tag != "Attack Bullet" && collision.tag != "Portal Bullet" && collision.tag != "Moving Platforms") && ! isAttached)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            hasTouched = true; 
            isAttached = true;
        }
    }
}
