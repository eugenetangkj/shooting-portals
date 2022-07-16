using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class will make a GameObject active in the scenes if the player enters its vicinity.
public class WheelEnable : MonoBehaviour
{
    [SerializeField] GameObject wheelTraps;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            wheelTraps.SetActive(true);
        }
    }
}
