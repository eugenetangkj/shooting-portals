using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class contains the data associated with the player,
//such as jump force and movement speed.
[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10f;



}
