using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class handles the logic for making enemies move predictably between 2 waypoints.
public class WayPointEnemyNormal : MonoBehaviour
{
    #region Waypoints Data
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;
    #endregion

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f) //Reached current waypoint, should move to next waypoint
        {
           currentWaypointIndex ++;
           if (currentWaypointIndex >= waypoints.Length) //Reached last waypoint
           {
               currentWaypointIndex = 0;
           }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        if (currentWaypointIndex == 0) 
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        else 
        {
            transform.localScale = new Vector2(1f, 1f);
        }
    }
}