using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a detector that will spawn the Boss Octopus instance if the player enters its collider.
public class SpawnBossOctopus : MonoBehaviour
{
    #region Spawn Data
    [SerializeField] private int roomDetected;
    [SerializeField] private BossOctopus bossOctopus;
    [SerializeField] private GameObject detector;
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            int playerCheckpoint = PlayerfabLoad.getPlayerCheckPoint();
            if ((roomDetected - 1 == playerCheckpoint) && (bossOctopus.gameObject.activeInHierarchy == false) && (bossOctopus.bossCheckpoint < roomDetected))
            {
                bossOctopus.spawnBossOctopus(roomDetected);
                bossOctopus.gameObject.SetActive(true);

            }
        }
    }

}
