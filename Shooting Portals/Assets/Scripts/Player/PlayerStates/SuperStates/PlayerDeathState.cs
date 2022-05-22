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
        restartAtCheckPoint();
    }

    public override void Exit()
    {
        base.Exit();
    }

    private void restartAtCheckPoint()
    {

    }
    

    
}
