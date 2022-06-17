using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDisappear : MonoBehaviour
{
    [SerializeField] GameObject water;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sensor")
        {
            destroyWater();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Sensor")
        {
            createWater();
            // foreach (Transform child in water.transform)
            // {
            //     child.gameObject.GetComponent<Animator>().SetBool("disappear", false);
            //     child.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            // }
        }
    }


    private void destroyWater()
    {
        Debug.Log("reachedOne");
        water.SetActive(false);
    }

    private void createWater()
    {
        Debug.Log("reachedTwo");
        water.SetActive(true);
    }

}
