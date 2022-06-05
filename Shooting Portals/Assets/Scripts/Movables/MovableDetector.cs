using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableDetector : MonoBehaviour
{

    [SerializeField] Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isInPushState && player.InputHandler.TeleportInput)
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
        else {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Movables")
        {
            if (player.FacingDirection == 1)
            {
                collision.transform.position = new Vector2(collision.transform.position.x + 2f, collision.transform.position.y);
            }
            else if (player.FacingDirection == -1)
            {
                collision.transform.position = new Vector2(collision.transform.position.x - 2f, collision.transform.position.y);
            }
            // this.GetComponent<MovableDetector>().enabled = false;
        }
    }

    // void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (collision.tag == "Movables")
    //     {
    //         this.GetComponent<BoxCollider2D>().enabled = false;    
    //     }
    // }
}
