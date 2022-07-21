using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is responsible for moving the acid wave in Level 10
public class AcidWave : MonoBehaviour
{
    [SerializeField] GameObject acid;
    [SerializeField] GameObject endPoint;
    [SerializeField] float speed;
    private bool shouldMove = false;
    private bool hasReached = false;

    private void Update()
    {
        if (shouldMove && ! hasReached)
        {
            //Boat moves towards destination
            acid.transform.position = Vector2.MoveTowards(acid.transform.position, endPoint.transform.position, Time.deltaTime * speed);
        }
        if (Vector2.Distance(acid.transform.position, endPoint.transform.position) < 0.1f)
        {
            hasReached = true;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player" && ! hasReached) 
        {
            //Start moving only when player comes into contact with the boat
            shouldMove = true;
        }
    }

}
