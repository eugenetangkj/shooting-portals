using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a checkpoint in a level
public class CheckPoint : MonoBehaviour
{
    #region Checkpoint Data
    [SerializeField] private int checkPointToSet;
    [SerializeField] private Player player;
    #endregion
    
    //Updates the player's checkpoint when the player passes this checkpoint, if and only if the player's current checkpoint is lower than
    //this checkpoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Player") && (player.playerCheckPoint < checkPointToSet))
        {
            PlayerfabLoad.updatePlayerCheckpoint(checkPointToSet.ToString());
        }
    }
}
