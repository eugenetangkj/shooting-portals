using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class will make a GameObject inactive in the scene if the player enters its vicinity.
public class WheelRemoval : MonoBehaviour
{
    [SerializeField] GameObject wheelTraps;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            wheelTraps.SetActive(false);
        }
    }
}
