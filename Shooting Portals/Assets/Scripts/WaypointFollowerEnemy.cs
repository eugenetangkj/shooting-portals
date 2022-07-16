using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is responsible for making an enemy move horizontally between 2 waypoints.
public class WaypointFollowerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;
    // Update is called once per frame
    private void Update()
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
        if (currentWaypointIndex == 0) 
        {
            transform.localScale = new Vector2(-0.75f, 0.75f);
        }
        else 
        {
            transform.localScale = new Vector2(0.75f, 0.75f);
        }
    }
}