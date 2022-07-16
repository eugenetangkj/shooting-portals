using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class encapsulates the state of the player touching a wall
public class PlayerTouchingWallState : PlayerState
{
    protected bool isGrounded;
    protected bool isTouchingWall;
    protected bool jumpInput;
    protected bool grabInput;
    protected int xInput;
    protected int yInput;

    public PlayerTouchingWallState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        yInput = player.InputHandler.NormInputY;
        jumpInput = player.InputHandler.JumpInput;
        grabInput = player.InputHandler.GrabInput;
        if (jumpInput) //Player wants to wall jump
        {
            player.WallJumpState.DetermineWallJumpDirection(isTouchingWall);
            stateMachine.ChangeState(player.WallJumpState);
        }
        else if (isGrounded && !grabInput) //Player is on the ground touching a wall but does not want to wall grab
        {
            stateMachine.ChangeState(player.IdleState);
            //Player is no longer touching a wall, or that player toggles Z and presses the left/right arrow key such that he does not want to wall grab
        } else if (!isTouchingWall || (xInput != player.FacingDirection && ! grabInput))
        {
            stateMachine.ChangeState(player.InAirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}