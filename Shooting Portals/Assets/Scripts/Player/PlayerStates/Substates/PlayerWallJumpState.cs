using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class encapsulates the wall jump state of the player.
public class PlayerWallJumpState : PlayerAbilityState
{
    private int wallJumpDirection;
    public PlayerWallJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.InputHandler.UseJumpInput();
        player.setVelocity(playerData.wallJumpVelocity, playerData.wallJumpAngle, wallJumpDirection);
        player.CheckIfShouldFlip(wallJumpDirection);
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //player.Anim.SetFloat("yVelocity", player.CurrentVelocity.y);
        //player.Anim.SetFloat("xVelocity", Mathf.Abs(player.CurrentVelocity.x));
        
        if (Time.time >= startTime + playerData.wallJumpTime)
        {
            isAbilityDone = true;
        }
    }

    public void DetermineWallJumpDirection(bool isTouchingWall)
    {
        if (isTouchingWall)
        {
            wallJumpDirection = - player.FacingDirection; //Jumps in the opposite direction of the wall
        } else
        {
            wallJumpDirection = player.FacingDirection;
        }
    }


}
