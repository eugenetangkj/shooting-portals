using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a sensor that would make a GameObject disappear with the condition that another similar sensor is activated.
public class SensorForDoorTwo : MonoBehaviour
{
    public bool canOpen {get; private set;} //Condition to check before the target GameObject disappears

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Sensor") //Move movable block over sensor
        {
           canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sensor") //Move movable block away from sensor
        {
            canOpen = false;
        }
    }
}