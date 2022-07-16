using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a tutorial instance
public abstract class Tutorial : MonoBehaviour
{
    protected Animator anim;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }


    protected abstract void OnTriggerEnter2D(Collider2D collision);

    protected abstract void OnTriggerExit2D(Collider2D collision);
}
