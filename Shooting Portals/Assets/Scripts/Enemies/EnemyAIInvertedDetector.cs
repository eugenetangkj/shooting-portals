using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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