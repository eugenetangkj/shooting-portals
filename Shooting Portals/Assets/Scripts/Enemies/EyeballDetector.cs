using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballDetector : MonoBehaviour
{
    [SerializeField] EnemyAI eyeball;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            eyeball.shouldReturn = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            eyeball.shouldReturn = true;
        }
    }
}