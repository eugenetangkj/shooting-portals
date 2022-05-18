using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerTouchingWallState
{

    private Animator dustWallAnimator;

    public PlayerWallSlideState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        player.setVelocityY(- playerData.wallSlideVelocity);

        if (yInput != -1 && grabInput)
        {
            stateMachine.ChangeState(player.WallGrabState);
        }
    }

    
}
