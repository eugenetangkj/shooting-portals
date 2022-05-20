using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivatedWaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;
    [SerializeField] private Collider2D trap;
    [SerializeField] private Collider2D moveableObject;
    // Update is called once per frame
    private void Update()
    {
        if (trap.IsTouching(moveableObject)) 
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
}
