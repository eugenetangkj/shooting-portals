using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBrick : MonoBehaviour
{
    private Vector2 originalPos;

    private void Start()
    {
        originalPos = this.transform.position;
    }
    public void fall()
    {
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

    }

    public void restore()
    {
        this.transform.position = originalPos;
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
}
