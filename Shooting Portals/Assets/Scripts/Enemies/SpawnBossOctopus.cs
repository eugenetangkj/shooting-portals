using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBossOctopus : MonoBehaviour
{
    [SerializeField] private int roomDetected;
    [SerializeField] private BossOctopus bossOctopus;
    [SerializeField] private GameObject detector;

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
