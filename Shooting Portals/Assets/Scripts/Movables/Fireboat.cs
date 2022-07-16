using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a boat instance that is used in Levels 6 and 8.
public class Fireboat : MonoBehaviour
{
    [SerializeField] GameObject fireBoat;
    [SerializeField] GameObject endPoint;
    [SerializeField] float speed;
    private bool shouldMove = false;

    private void Update()
    {
        if (shouldMove)
        {
            //Boat moves towards destination
            fireBoat.transform.position = Vector2.MoveTowards(fireBoat.transform.position, endPoint.transform.position, Time.deltaTime * speed);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player") 
        {
            //Start moving only when player comes into contact with the boat
            shouldMove = true;
        }
    }

}
