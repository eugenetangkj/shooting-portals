using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
