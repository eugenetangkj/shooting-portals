using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class can be attached to any GameObject that has a collider set to trigger mode. If the player touches a GameObject with this class attached to it, the player
//will transition into the death state.
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
