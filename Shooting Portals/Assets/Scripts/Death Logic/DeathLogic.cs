using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLogic : MonoBehaviour
{
    [SerializeField] private Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.StateMachine.ChangeState(player.DeathState);
        }
    }
}
