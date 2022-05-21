using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryForPushing : MonoBehaviour
{
    [SerializeField] private Player player;

    // Update is called once per frame
    void Update()
    {
        checkForPlayer();
        
    }

    void checkForPlayer()
    {
        if (player.InputHandler.PushInput == true)
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
        } else {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
