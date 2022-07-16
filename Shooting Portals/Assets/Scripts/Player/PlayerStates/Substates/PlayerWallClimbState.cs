using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents the wall climb state of the player.
public class PlayerWallClimbState : PlayerTouchingWallState
{

    private AudioSource wallMovementSound;
    public PlayerWallClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        wallMovementSound = player.pushSound;
        wallMovementSound.Play();
    }

    public override void Exit()
    {
        wallMovementSound.Stop();
        base.Exit();
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!isExitingState)
        {
            player.setVelocityY(playerData.wallClimbVelocity);
            if (yInput != 1) //Player is not pressing the up arrow key
            {
                stateMachine.ChangeState(player.WallGrabState);
            }
        }
    }
}
