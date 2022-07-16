using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This state encapsulates the player state of jumping
public class PlayerJumpState : PlayerAbilityState
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.jumpSound.Play();
        player.InputHandler.UseJumpInput();
        player.InputHandler.GrabInput = false;
        player.setVelocityY(playerData.jumpVelocity); //Sets velocity upwards
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
