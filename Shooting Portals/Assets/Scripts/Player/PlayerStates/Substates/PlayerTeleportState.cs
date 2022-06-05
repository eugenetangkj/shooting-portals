using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportState : PlayerAbilityState
{
    public PlayerTeleportState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        player.teleportSound.Play();
        //player.InputHandler.PushInput = false;
        player.transform.position = Portal.getPositionToTeleport(); //Teleports the player

        // if (Portal.portalToTeleportTo.gameObject.tag == "Portal 2") //Go from portal 2 to portal 1
        // {
        //     float directionRequired = - Player.ShootDirection[0]; 
        //     if (directionRequired == player.FacingDirection)
        //     {
        //      player.flip();   
        //     }
        // } else if (Portal.portalToTeleportTo.gameObject.tag == "Portal 1") //Go from portal 1 to portal 2
        // {
        //     float directionRequired = - Player.ShootDirection[1]; 
        //     if (directionRequired == player.FacingDirection)
        //     {
        //      player.flip();   
        //     }
        // }
        player.InputHandler.UseTeleportInput();
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
