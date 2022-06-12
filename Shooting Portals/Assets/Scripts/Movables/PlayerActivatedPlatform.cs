using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActivatedPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject platform;

    private int moveDirection;

    private void Update()
    {
        if (moveDirection == 1)
        {
           platform.transform.position = Vector2.MoveTowards(platform.transform.position, waypoints[1].transform.position, Time.deltaTime * speed); 
        } else if (moveDirection == -1)
        {
           platform.transform.position = Vector2.MoveTowards(platform.transform.position, waypoints[0].transform.position, Time.deltaTime * speed); 
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            moveDirection = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            moveDirection = -1;
        }
    }
}
