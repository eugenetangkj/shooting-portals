using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpaceBar : Tutorial
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("appear", true);
        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("appear", false);
        }
    }
}

