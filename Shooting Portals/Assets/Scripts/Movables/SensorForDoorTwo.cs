using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorForDoorTwo : MonoBehaviour
{
    public bool canOpen {get; private set;}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Sensor")
        {
           canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sensor")
        {
            canOpen = false;
        }
    }
}