using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a vertical bee trap in Level 5
public class VerticalBeeSmash : MonoBehaviour
{
    #region Bee Data
    private Vector2 originalPos;
    private bool shouldReset;
    private bool hasTouched;
    private bool isAttached;
    [SerializeField] private float beeVerticalSpeed = 4f; //Vertical speed of bee
    [SerializeField] private float beeStartTime = 1f; //Time at which bee will start falling from time of awake
    [SerializeField] private float beeTravelDuration = 8f; //Duration over which bee will fall before respawning at the top of the scene again

    #endregion

    private void Start()
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
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f); //Sets bee to be stationary
            this.transform.position = originalPos;
            hasTouched = false;
            isAttached = false;
        }
        else if (! shouldReset && ! hasTouched)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, - beeVerticalSpeed); //Sets bee moving downwards vertically
        }
    }

    private void toggleShouldReset()
    {
        shouldReset = (shouldReset) ? false : true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Moving Platforms" && ! isAttached) //If bee collides with a moving platform and is not currently attached to any other platforms
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            hasTouched = true;
            this.gameObject.transform.SetParent(collision.gameObject.transform);
            isAttached = true;

        }
        else if ((collision.tag != "Portal" && collision.tag != "Attack Bullet" && collision.tag != "Portal Bullet" && collision.tag != "Moving Platforms") && ! isAttached)
        { //Bee will move downwards as long as it does not hit any objects of the above tags
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            hasTouched = true; 
            isAttached = true;
        }
    }
}
