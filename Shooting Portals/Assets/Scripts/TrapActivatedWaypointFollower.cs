using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class contains the logic for making a platform moving horizontally between 2 waypoints if and only if a sensor is activated.
public class TrapActivatedWaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;


    public bool shouldMove = false;

    // Update is called once per frame
    private void Update()
    {
        if (shouldMove) //Sensor-activated
        {
            MovePlatform();
        }
    }

    private void MovePlatform () 
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f) 
        {
           currentWaypointIndex ++;
           if (currentWaypointIndex >= waypoints.Length)
           {
               currentWaypointIndex = 0;
           }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }

    public void toggleShouldMove()
    {
        shouldMove = (shouldMove == true) ? false : true;
    }
}
