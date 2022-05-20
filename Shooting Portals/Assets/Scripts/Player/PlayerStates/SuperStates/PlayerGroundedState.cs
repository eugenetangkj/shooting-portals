using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;

    private bool jumpInput;

    private bool isGrounded;

    private bool isTouchingWall;

    private bool grabInput;

    private bool attackShootInput;

    private bool portalShootInput;

    private bool teleportInput;



    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        jumpInput = player.InputHandler.JumpInput;
        grabInput = player.InputHandler.GrabInput;
        attackShootInput = player.InputHandler.AttackShootInput;
        portalShootInput = player.InputHandler.PortalShootInput;
        teleportInput = player.InputHandler.TeleportInput;

        if (jumpInput)
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if (isTouchingWall && grabInput)
        {
            stateMachine.ChangeState(player.WallGrabState);
        } else if (attackShootInput)
        {
            stateMachine.ChangeState(player.AttackShootState);
        } else if (portalShootInput)
        {
            stateMachine.ChangeState(player.PortalShootState);
        } else if (teleportInput)
        {
            stateMachine.ChangeState(player.TeleportState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
