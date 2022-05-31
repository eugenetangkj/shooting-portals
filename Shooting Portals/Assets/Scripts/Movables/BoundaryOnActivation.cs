using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryOnActivation : Tutorial
{
    [SerializeField] private GameObject boundary;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            boundary.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            boundary.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}