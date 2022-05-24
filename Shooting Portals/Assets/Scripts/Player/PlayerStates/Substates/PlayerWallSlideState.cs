using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerTouchingWallState
{
    
    private Animator dustWallAnimator;

    private AudioSource wallMovementSound;

    public PlayerWallSlideState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
            player.setVelocityY(- playerData.wallSlideVelocity);

            if (yInput != -1 && grabInput)
            {
                stateMachine.ChangeState(player.WallGrabState);
            }
        }
    }

    
}
