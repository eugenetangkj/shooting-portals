using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatformIShape : MonoBehaviour
{
    [SerializeField] private GameObject platform;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player") 
        {
            collision.gameObject.transform.SetParent(platform.transform);
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
