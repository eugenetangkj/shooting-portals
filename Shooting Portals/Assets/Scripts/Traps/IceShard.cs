using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShard : MonoBehaviour
{
    private Vector2 originalPos;
    private bool shouldReset;
    private bool isReseting;


    private Animator anim;
    [SerializeField] private float shardVerticalSpeed = 4f;


    void Start()
    {
        originalPos = this.transform.position;
        shouldReset = true;
        isReseting = false;

        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldReset)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            isReseting = false;
            this.transform.position = originalPos;
            anim.SetBool("destroy", false);
            toggleShouldReset();

        }
        else if (! shouldReset && ! isReseting)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, - shardVerticalSpeed);
        }
    }

    private void toggleShouldReset()
    {
        shouldReset = (shouldReset) ? false : true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "JumpableGround")
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            isReseting = true;
            anim.SetBool("destroy", true);
            Invoke("toggleShouldReset", 0.3f);
        }
    }

}
