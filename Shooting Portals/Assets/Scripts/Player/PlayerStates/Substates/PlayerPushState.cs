using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPushState : PlayerGroundedState
{
    public PlayerPushState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.InputHandler.UsePushInput();
    }


    public override void Exit()
    {
        base.Exit();
    }



    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }


    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (player.InputHandler.NormInputX != 0)
        {
            player.Anim.SetInteger("pushMove", 1);
        } else
        {
            player.Anim.SetInteger("pushMove", 0);
        }
        player.setVelocityX(playerData.movementVelocity * xInput * 0.5f);
    }

}
