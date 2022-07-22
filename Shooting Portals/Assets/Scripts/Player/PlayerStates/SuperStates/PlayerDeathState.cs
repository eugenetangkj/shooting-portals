using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents the death state of the player
public class PlayerDeathState : PlayerState
{
    private bool playedSoundBefore = false;
    public PlayerDeathState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }


    public override void Enter()
    {
        if (! playedSoundBefore)
        {
        playedSoundBefore = true;
        player.defeatedSound.Play();
        }
        player.pushSound.Stop();
        player.setVelocityZero(); //Set velocity of player to be 0
        base.Enter();
        Portal.portalCount = 0; //Resets portal count
        Portal.portalArray[0] = null;
        Portal.portalArray[1] = null;
        player.Invoke("restartLevel", 2.5f); //Restarts level
    }

    public override void Exit()
    {
        base.Exit();
    }

    

    
}
