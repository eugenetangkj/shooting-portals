using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;

    private bool jumpInput;

    private bool isGrounded;

    private bool isTouchingWall;

    private bool isTouchingMovable;

    private bool isTouchingGroundLedge;

    private bool grabInput;

    private bool attackShootInput;

    private bool portalShootInput;

    private bool teleportInput;
    
    private bool pushInput;



    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    
    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.CheckIfGrounded();
        isTouchingWall = player.CheckIfTouchingWall();
        isTouchingMovable = player.CheckIfTouchingMovable();
        isTouchingGroundLedge = player.CheckIfGroundLedge();
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
        teleportInput = player.InputHandler.TeleportInput;
        pushInput = player.InputHandler.PushInput;

        if (jumpInput && ! pushInput)
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if (isTouchingWall && grabInput)
        {
            stateMachine.ChangeState(player.WallGrabState);
        }
        else if (teleportInput)
        {
            stateMachine.ChangeState(player.TeleportState);
        }
        else if (isGrounded && ! isTouchingGroundLedge)
        {
            stateMachine.ChangeState(player.IdleState);
            player.InputHandler.PushInput = false;
        }
        
        else if (isTouchingMovable && pushInput)
        {
            stateMachine.ChangeState(player.PushState);
        }
        else if (isTouchingMovable && ! pushInput)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else if (attackShootInput && ! pushInput)
        {   stateMachine.ChangeState(player.AttackShootState);
        }  
        else if (portalShootInput && !pushInput)
        {
            stateMachine.ChangeState(player.PortalShootState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
