using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a detector. If a Stomper instance enters its collider, it causes the Stomper to stop running.
public class StopStomper : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Stomper")
        {
            collision.gameObject.GetComponent<Stomper>().stopRunning();
        }
    }
}
