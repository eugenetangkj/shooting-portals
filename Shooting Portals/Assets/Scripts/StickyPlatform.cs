using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class handles the logic for making the player move automatically with a moving platform.
public class StickyPlatform : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player") 
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.tag == "Player") 
        {
            collision.gameObject.transform.SetParent(null);
            collision.gameObject.transform.eulerAngles = new Vector3(0f, collision.gameObject.transform.rotation.y * 180, 0f);
        }
    }

}
