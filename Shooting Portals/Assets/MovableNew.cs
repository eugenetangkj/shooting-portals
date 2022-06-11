using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableNew : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject box;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    // Update is called once per frame
    void Update()
    {
        if ((player.CheckTouchingWhichMovable() == this.GetComponent<BoxCollider2D>()) || (player.CheckTouchingWhichMovableTwo() == box.GetComponent<BoxCollider2D>()))
        {    
            if (player.CheckIfTouchingMovable() && player.InputHandler.PushInput)
            {
                this.GetComponent<BoxCollider2D>().enabled = false;
                this.gameObject.transform.SetParent(player.gameObject.transform);
                box.SetActive(true);
            }
            else if (! player.InputHandler.PushInput)
            {
                this.GetComponent<BoxCollider2D>().enabled = true;
                this.gameObject.transform.SetParent(null);
                box.SetActive(false);
            }
        }
        
    }
}
