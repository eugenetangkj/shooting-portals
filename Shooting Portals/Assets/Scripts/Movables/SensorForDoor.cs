using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorForDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;


    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Sensor")
        {
           door.GetComponent<Animator>().SetBool("disappear", true);
           door.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sensor")
        {
            door.GetComponent<Animator>().SetBool("disappear", false);
            door.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}