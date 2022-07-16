using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class handles the camera view of the level scenes
public class RoomManager : MonoBehaviour
{
    public GameObject virtualCam;
    private void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.CompareTag("Player") && !other.isTrigger) //When player enters the room
        {
            virtualCam.SetActive(true);
        }
    }
    private void OnTriggerExit2D (Collider2D other) 
    {
        if (other.CompareTag("Player") && !other.isTrigger) //When player leaes the room
        {
            virtualCam.SetActive(false);
        }
    }
}
