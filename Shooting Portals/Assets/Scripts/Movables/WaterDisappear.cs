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
            Debug.Log("reachedOne");
            foreach (Transform child in water.transform)
            {
                child.gameObject.GetComponent<Animator>().SetBool("disappear", true);
                child.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                
            }
            Invoke("destroyWater", 1.2f);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Sensor")
        {
            Debug.Log("reachedTwo");
            createWater();
            foreach (Transform child in water.transform)
            {
                child.gameObject.GetComponent<Animator>().SetBool("disappear", false);
                child.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                
            }
        }
    }


    private void destroyWater()
    {
        water.SetActive(false);
    }

    private void createWater()
    {
        water.SetActive(true);
    }

}
