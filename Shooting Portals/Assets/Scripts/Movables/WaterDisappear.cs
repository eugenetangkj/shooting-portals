using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class handles the logic of making a GameObject disappear if a movable block enters its collider
public class WaterDisappear : MonoBehaviour
{
    [SerializeField] GameObject water;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sensor") //Movable block enters
        {
            destroyWater();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Sensor") //Movable block leaves
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
        water.SetActive(false);
    }

    private void createWater()
    {
        water.SetActive(true);
    }

}
