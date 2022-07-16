using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a sensor that would make a GameObject disappear and remove its box collider
public class SensorForDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;


    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Sensor") //Movable block is moved over the sensor
        {
           door.GetComponent<Animator>().SetBool("disappear", true);
           door.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sensor") //Movable block is moved away from the sensor
        {
            door.GetComponent<Animator>().SetBool("disappear", false);
            door.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}