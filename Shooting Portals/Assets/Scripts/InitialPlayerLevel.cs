using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPlayerLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerfabLoad.getPlayerLevelBefore();  
    }
}
