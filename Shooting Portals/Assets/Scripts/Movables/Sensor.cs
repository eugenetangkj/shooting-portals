using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a sensor that would activate a TrapActivatedWaypointFollower
public class Sensor : MonoBehaviour
{
    [SerializeField] private TrapActivatedWaypointFollower trapActivatedWaypointFollower;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Sensor")
        {
            trapActivatedWaypointFollower.shouldMove = true; //When movable block moves over it
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sensor")
        {
            trapActivatedWaypointFollower.shouldMove = false; //When movable block moves away from it
        }
    }
}
