using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a sensor that would deactivate two fireballs when a movable block moves over it.
public class SensorForFire : MonoBehaviour
{
    [SerializeField] GameObject fireballOne;
    [SerializeField] GameObject fireballTwo;

    private Animator animOne;
    private Animator animTwo;


    private void Start()
    {
        animOne = fireballOne.GetComponent<Animator>();
        animTwo = fireballTwo.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sensor") //Move movable block over it
        {
            animOne.SetBool("reset", true);
            animTwo.SetBool("reset", true);
            //fireballOne.SetActive(false);
            //fireballTwo.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Sensor") //Move movable block away from it
        {
            animOne.SetBool("reset", false);
            animTwo.SetBool("reset", false);
            //fireballOne.SetActive(true);
            //fireballTwo.SetActive(true);
        }
    }
}
