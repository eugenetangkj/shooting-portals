using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPushState : PlayerGroundedState
{

    private AudioSource pushingSound;

    private bool shouldPlayAudio;
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
        pushingSound = player.pushSound;
        player.togglePlayerInPushState();
    }


    public override void Exit()
    {
        // if (pushingSound.isPlaying)
        // {
        //     pushingSound.Stop();
        // }
        player.togglePlayerInPushState();
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
            if (! pushingSound.isPlaying)
            {
                pushingSound.Play();
            }
        }
        else
        {
            player.Anim.SetInteger("pushMove", 0);
            pushingSound.Stop();
        }
        player.setVelocityX(playerData.movementVelocity * xInput * 0.3f);
    }

}
