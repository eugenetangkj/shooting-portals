using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a movable block.
public class MovableNew : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject box;
    


    private void Start()
    {
        
    }

   

    private void Update()
    {
        //Checks which movable instance in the scene is the player in contact with
        if ((player.CheckTouchingWhichMovable() == this.GetComponent<BoxCollider2D>()) || (player.CheckTouchingWhichMovableTwo() == box.GetComponent<BoxCollider2D>()))
        {
            //Player is touching a movable instance and there is push input    
            if (player.CheckIfTouchingMovable() && player.InputHandler.PushInput)
            {
                this.GetComponent<BoxCollider2D>().enabled = false;
                this.gameObject.transform.SetParent(player.gameObject.transform);
                box.SetActive(true);
            }
            //Player has no push input
            else if (! player.InputHandler.PushInput)
            {
                this.GetComponent<BoxCollider2D>().enabled = true;
                this.gameObject.transform.SetParent(null);
                box.SetActive(false);
            }
        }
        
    }
}
