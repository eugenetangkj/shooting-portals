using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    [SerializeField] private TrapActivatedWaypointFollower trapActivatedWaypointFollower;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Sensor")
        {
            trapActivatedWaypointFollower.shouldMove = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sensor")
        {
            trapActivatedWaypointFollower.shouldMove = false;
        }
    }
}
