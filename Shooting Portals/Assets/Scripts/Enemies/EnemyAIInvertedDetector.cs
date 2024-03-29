using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a detector for an EnemyAIInverted instance. If the player enters into its collider,
//it will activate the EnemyAiInvertedInstance.
public class EnemyAIInvertedDetector : MonoBehaviour
{
    [SerializeField] EnemyAIInverted enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemy.shouldReturn = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemy.shouldReturn = true;
        }
    }
}