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
        
        //player.transform.position = Portal.getPositionToTeleport(); //Teleports the player

        float offsetRequired = 0;
        if (Portal.portalToTeleportTo.gameObject.tag == "Portal 2" && player.InputHandler.PushInput) //Go from portal 2 to portal 1
        {
            //Debug.Log("1. Player Shoot Direction: " + Player.ShootDirection[1]);
            offsetRequired = Player.ShootDirection[1] * -1.25f;
        }
        else if (Portal.portalToTeleportTo.gameObject.tag == "Portal 1" && player.InputHandler.PushInput) //Go from portal 1 to portal 2
        {
            offsetRequired = Player.ShootDirection[0] * -1.25f;
            //Debug.Log("2. Player Shoot Direction: " + Player.ShootDirection[0]);
        }
        else if (Portal.portalToTeleportTo.gameObject.tag == "Portal 2")
        {
           offsetRequired = Player.ShootDirection[1] * -0.1f; 
        } else if (Portal.portalToTeleportTo.gameObject.tag == "Portal 1")
        {
           offsetRequired = Player.ShootDirection[0] * -0.1f; ; //Player.ShootDirection[0] * -0.01f; 
        }
        
        
        player.transform.position = new Vector2(Portal.getPositionToTeleport().x + offsetRequired, Portal.getPositionToTeleport().y);



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