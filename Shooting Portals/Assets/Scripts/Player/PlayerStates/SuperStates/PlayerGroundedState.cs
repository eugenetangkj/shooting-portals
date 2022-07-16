using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents the state of the player being on the ground
public class PlayerGroundedState : PlayerState
{
    protected int xInput;

    private bool jumpInput;

    private bool isGrounded;

    private bool isTouchingWall;

    private bool isTouchingMovable;

    private bool isAtGroundLedgeAndPush;

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
        isAtGroundLedgeAndPush = player.CheckIfGroundLedge();
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



        if (jumpInput && ! pushInput) //Player wants to jump and is not pushing
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if (isTouchingWall && grabInput) //Player is touching a wall and wants top wall grab
        {
            stateMachine.ChangeState(player.WallGrabState);
        }
        else if (teleportInput) //Player wants to teleport
        {
            stateMachine.ChangeState(player.TeleportState);
        }
        else if (attackShootInput && ! pushInput) //Player wants to attack shoot and is not pushing
        {   stateMachine.ChangeState(player.AttackShootState);
        }
         else if (portalShootInput && !pushInput) //Player wants to portal shoot and is not pushing
        {
            stateMachine.ChangeState(player.PortalShootState);
        }  
        else if (isTouchingMovable && ! pushInput) //Player is touching a movable block but does not want to push
        {
            stateMachine.ChangeState(player.IdleState);
        } else if (player.isInPushState && ! pushInput) //Player is pushing and toggles X, means does not want to push
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else if (isTouchingMovable && pushInput) //Player is touching a movable and wants to push
        {
            stateMachine.ChangeState(player.PushState);
        }
        //OLD, rearranged order above
        // else if (attackShootInput && ! pushInput)
        // {   stateMachine.ChangeState(player.AttackShootState);
        // }  
        // else if (portalShootInput && !pushInput)
        // {
        //     stateMachine.ChangeState(player.PortalShootState);
        // }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}