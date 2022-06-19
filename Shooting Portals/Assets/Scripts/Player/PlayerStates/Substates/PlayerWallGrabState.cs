using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallGrabState : PlayerTouchingWallState
{
    private Vector2 holdPosition;
    public PlayerWallGrabState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        Debug.Log("IN WALL GRAB STATE");
        base.Enter();
        // holdPosition = player.transform.position;
        // HoldPosition();
        player.GetComponent<Rigidbody2D>().gravityScale = 0f;
    }

    

    public override void Exit()
    {
        base.Exit();
        player.GetComponent<Rigidbody2D>().gravityScale = 5f;
    }

    

    public override void LogicUpdate()
    {
        Debug.Log(grabInput);
        base.LogicUpdate();
        

        if (!isExitingState)
        {
            HoldPosition();
            if (yInput > 0 && grabInput)
            {
                stateMachine.ChangeState(player.WallClimbState);
            } else if (yInput < 0 && grabInput)
            {
                stateMachine.ChangeState(player.WallSlideState);
            }
        }
    }

    private void HoldPosition()
    {
        //player.transform.position = holdPosition;
        player.setVelocityX(0f);
        player.setVelocityY(0f);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

   
}
