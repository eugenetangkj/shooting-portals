using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
