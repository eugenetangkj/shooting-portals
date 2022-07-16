using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class encapsulates the state of the player shooting a portal while in the air
public class PlayerPortalShootJumpState : PlayerAbilityState
{
    public PlayerPortalShootJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        player.portalShootSound.Play();
        player.InputHandler.UsePortalShootInput();
        player.PortalShootJumpAttack();
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
