using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents an ice shard trap in Level 8
public class IceShard : MonoBehaviour
{
    private Vector2 originalPos;
    private bool shouldReset;
    private bool isReseting;


    private Animator anim;
    [SerializeField] private float shardVerticalSpeed = 4f; //Speed at which ice shard drops


    private void Start()
    {
        originalPos = this.transform.position;
        shouldReset = true;
        isReseting = false;

        anim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        if (shouldReset)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f); //Sets ice shard to be stationary
            isReseting = false;
            this.transform.position = originalPos; //Brings ice shard back to original position
            anim.SetBool("destroy", false);
            toggleShouldReset();

        }
        else if (! shouldReset && ! isReseting)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, - shardVerticalSpeed); //Moves ice shard downwards vertically
        }
    }

    private void toggleShouldReset()
    {
        shouldReset = (shouldReset) ? false : true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If ice shard touches ground, stop moving downwards and play shatter animation
        if (collision.tag == "JumpableGround") 
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            isReseting = true;
            anim.SetBool("destroy", true);
            Invoke("toggleShouldReset", 0.3f);
        }
    }

}
