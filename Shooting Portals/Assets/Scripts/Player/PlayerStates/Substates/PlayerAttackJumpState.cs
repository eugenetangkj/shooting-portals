using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class encapsulates the state of the player attacking while in air.
public class PlayerAttackJumpState : PlayerAbilityState
{
    public PlayerAttackJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        player.attackSound.Play();
        player.InputHandler.UseAttackShootInput();
        player.ShootJumpAttack();
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
