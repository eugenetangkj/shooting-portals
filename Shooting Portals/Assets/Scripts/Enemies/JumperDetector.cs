using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a detector for EnemyAIDelayed. If player enters into its vicinity, it will activate its associated EnemyAIDelayed to move
//towards the player.
public class JumperDetector : MonoBehaviour
{
    [SerializeField] EnemyAIDelayed jumper;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            jumper.shouldReturn = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            jumper.shouldReturn = true;
        }
    }
}