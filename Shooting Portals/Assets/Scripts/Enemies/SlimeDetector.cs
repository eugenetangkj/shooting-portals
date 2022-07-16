using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a detector for an EnemyAILeftRight. If player enters its collider, it activates its associated EnemyAILeftRight to move towards the player.
public class SlimeDetector : MonoBehaviour
{
    [SerializeField] EnemyAILeftRight slime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            slime.shouldReturn = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            slime.shouldReturn = true;
        }
    }
}
