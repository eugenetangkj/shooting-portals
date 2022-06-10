using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        player.setVelocityZero();
        base.Enter();
        Portal.portalCount = 0;
        player.Invoke("restartLevel", 2.5f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    

    
}
