using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            fireBoat.transform.position = Vector2.MoveTowards(fireBoat.transform.position, endPoint.transform.position, Time.deltaTime * speed);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player") 
        {
            shouldMove = true;
        }
    }

}
