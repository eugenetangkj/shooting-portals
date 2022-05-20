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
        player.transform.position = Portal.getPositionToTeleport();
        player.InputHandler.UseTeleportInput();
        isAbilityDone = true;
    }

    
    public override void Exit()
    {
        float directionRequired;
        if (Portal.portalToTeleportTo.gameObject.tag == "Portal 1") //When teleporting to portal 2
        {
            Debug.Log(player.ShootDirection[1]);
            directionRequired = player.ShootDirection[1] == 0 ? -1 : 1;
            player.CheckIfShouldFlip((int) directionRequired);
        } else if (Portal.portalToTeleportTo.gameObject.tag == "Portal 2") //When teleporting to portal 1
        {
            directionRequired = player.ShootDirection[0] == 0 ? -1 : 1;
            player.CheckIfShouldFlip((int) directionRequired);
        }   
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
