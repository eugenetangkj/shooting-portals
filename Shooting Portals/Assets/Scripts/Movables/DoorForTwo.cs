using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents an object that will only disappear and have its collider set to inactive when two sensors are activated
public class DoorForTwo : MonoBehaviour
{
    [SerializeField] private SensorForDoorTwo sensorOne;
    [SerializeField] private SensorForDoorTwo sensorTwo;



    // Update is called once per frame
    void Update()
    {
        if (sensorOne.canOpen && sensorTwo.canOpen)
        {
            this.GetComponent<Animator>().SetBool("disappear", true);
            this.GetComponent<BoxCollider2D>().enabled = false;
        } else
        {
            this.GetComponent<Animator>().SetBool("disappear", false);
            this.GetComponent<BoxCollider2D>().enabled = true;     
        }
        
    }
}
