using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
