using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorForFire : MonoBehaviour
{
    [SerializeField] GameObject fireballOne;
    [SerializeField] GameObject fireballTwo;

    [SerializeField] Animator animOne;
    [SerializeField] Animator animTwo;


    private void Start()
    {
        animOne = fireballOne.GetComponent<Animator>();
        animTwo = fireballTwo.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sensor")
        {
            animOne.SetBool("reset", true);
            animTwo.SetBool("reset", true);
            //fireballOne.SetActive(false);
            //fireballTwo.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Sensor")
        {
            animOne.SetBool("reset", false);
            animTwo.SetBool("reset", false);
            //fireballOne.SetActive(true);
            //fireballTwo.SetActive(true);
        }
    }
}
