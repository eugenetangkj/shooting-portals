using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class encapsulates the state in which the player is moving
public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
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
        player.InputHandler.GrabInput = false;
        player.CheckIfShouldFlip(xInput);

        player.setVelocityX(playerData.movementVelocity * xInput);
        
        if (xInput == 0f && !isExitingState) //No movement left and right
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
