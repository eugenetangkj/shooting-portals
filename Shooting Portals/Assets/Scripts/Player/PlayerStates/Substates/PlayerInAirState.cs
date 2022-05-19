using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private bool isGrounded;
    private int xInput;

    private bool isTouchingWall;

    private bool isTouchingWallBack;

    private bool jumpInput;

    private bool grabInput;

    private bool isTouchingLedge;

    private bool attackShootInput;

    private bool portalShootInput;

    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.CheckIfGrounded();
        isTouchingWall = player.CheckIfTouchingWall();
        isTouchingWallBack = player.CheckIfTouchingWallBack();
        isTouchingLedge = player.CheckIfTouchingLedge();

        if (isTouchingWall && !isTouchingLedge)
        {
            player.LedgeClimbState.SetDetectedPosition(player.transform.position);
        }
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
        jumpInput = player.InputHandler.JumpInput;
        grabInput = player.InputHandler.GrabInput;
        attackShootInput = player.InputHandler.AttackShootInput;
        portalShootInput = player.InputHandler.PortalShootInput;
        
        //Player touches ground, goes to idle state
        if (isGrounded && player.CurrentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        //Player is in the air, and wants to shoot
        else if (attackShootInput)
        {
            stateMachine.ChangeState(player.AttackJumpState);
        }
        //Player is in the air, and wants to portal shoot
        else if (portalShootInput)
        {
            stateMachine.ChangeState(player.PortalShootJumpState);
        }
        //Player is at a ledge and wants to hold onto the ledge, goes to ledgeclimb state    
        else if (isTouchingWall && !isTouchingLedge && grabInput)
        {
            stateMachine.ChangeState(player.LedgeClimbState);
        }
        //Player is touching a wall and wants to wall jump, goes to walljump state
        else if (jumpInput && (isTouchingWall || isTouchingWallBack))
        {
            isTouchingWall = player.CheckIfTouchingWall();
            player.WallJumpState.DetermineWallJumpDirection(isTouchingWall);
            stateMachine.ChangeState(player.WallJumpState);
        
        }
        //Player is touching a wall and wants to wall grab, goes to wallgrab state    
        else if (isTouchingWall && grabInput)
        {
            stateMachine.ChangeState(player.WallGrabState);
        }
        //Player is touching a wall and does not wall grab, goes to wallslide state
        else if (isTouchingWall && xInput == player.FacingDirection)
        {
            stateMachine.ChangeState(player.WallSlideState);
        } 
        //Player wants to move in the air
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
