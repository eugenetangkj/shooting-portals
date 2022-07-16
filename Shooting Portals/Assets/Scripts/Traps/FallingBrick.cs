using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a falling trap brick in Level 2
public class FallingBrick : MonoBehaviour
{
    private Vector2 originalPos;

    private void Start()
    {
        originalPos = this.transform.position;
    }

    //Makes the brick fall vertically downwards
    public void fall()
    {
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

    }
    //Restores the brick back to its original position
    public void restore()
    {
        this.transform.position = originalPos;
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
}
