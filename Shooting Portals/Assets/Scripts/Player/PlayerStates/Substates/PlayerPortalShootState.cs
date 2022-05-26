using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPortalShootState : PlayerAbilityState
{
    public PlayerPortalShootState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        player.InputHandler.UsePortalShootInput();
        player.PortalShootAttack();
        isAbilityDone = true;
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
    }

   
}
