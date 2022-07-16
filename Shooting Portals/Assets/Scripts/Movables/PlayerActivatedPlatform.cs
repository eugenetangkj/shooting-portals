using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a player-activated platform.
public class PlayerActivatedPlatform : MonoBehaviour
{
    #region Player-activated Platform Data
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject animatedTransition;

    private int moveDirection; //Default value is 0, so platform does not move until player enters
    #endregion


    private void Update()
    {
        if (moveDirection == 1) //Moving towards the second waypoint
        {
           platform.transform.position = Vector2.MoveTowards(platform.transform.position, waypoints[1].transform.position, Time.deltaTime * speed); 
        } else if (moveDirection == -1) //Moving towards the first waypoint
        {
           platform.transform.position = Vector2.MoveTowards(platform.transform.position, waypoints[0].transform.position, Time.deltaTime * speed); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            moveDirection = 1; //Will move to second waypoint if player is on the platform
            if (animatedTransition != null)
            {
            animatedTransition.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") //Will move back to first waypoint if player leaves the platform
        {
            moveDirection = -1;
        }
    }
}
