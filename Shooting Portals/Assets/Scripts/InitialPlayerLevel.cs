using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class retrieves the player level from Playfab once it is instantiated
public class InitialPlayerLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        PlayerfabLoad.getPlayerLevelBefore();  
    }
}
