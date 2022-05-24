using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private int checkPointToSet ;
    [SerializeField] private Player player;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Player") && (player.playerCheckPoint < checkPointToSet))
        {
            PlayerfabLoad.updatePlayerCheckpoint(checkPointToSet.ToString());
            Portal.destroyAllPortals();
        } else if ((collision.tag == "Player"))
        {
            Portal.destroyAllPortals();
        }
    }
}
