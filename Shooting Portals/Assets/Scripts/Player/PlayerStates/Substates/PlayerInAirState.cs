using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private bool isGrounded;
    private int xInput;

    private bool isTouchingWall;

    private bool grabInput;

    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.CheckIfGrounded();
        isTouchingWall = player.CheckIfTouchingWall();
    }

    public override void Enter()
    {
        base.Enter();
    }

    

    public override void Exit()
    {
        base.Exit();
    }

    

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = player.InputHandler.NormInputX;
        grabInput = player.InputHandler.GrabInput;

        if (isGrounded && player.CurrentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.IdleState);
        } else if (isTouchingWall && grabInput)
        {
            stateMachine.ChangeState(player.WallGrabState);
        } else if (isTouchingWall && xInput == player.FacingDirection)
        {
            stateMachine.ChangeState(player.WallSlideState);
        } 
         else
        {
            player.CheckIfShouldFlip(xInput);
            player.setVelocityX(playerData.movementVelocity * xInput); 
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    
}
