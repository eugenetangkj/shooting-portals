using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerState
{
    public PlayerDeathState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }


    public override void Enter()
    {
        player.pushSound.Stop();
        player.defeatedSound.Play();
        player.setVelocityZero();
        base.Enter();
        player.Invoke("restartLevel", 3.5f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    

    
}
