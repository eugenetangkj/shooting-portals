using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class encapsulates the state of the player doing a ledge climb
public class PlayerLedgeClimbState : PlayerState
{
    private Vector2 detectedPos;
    private Vector2 cornerPos;
    private Vector2 startPos;
    private Vector2 stopPos;
    private bool isHanging;
    private bool isClimbing;

    private int xInput;
    private int yInput;
    public PlayerLedgeClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        player.Anim.SetBool("climbLedge", false);
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
        isHanging = true;
    }

    public override void Enter()
    {
        base.Enter();

        player.setVelocityZero();
        player.transform.position = detectedPos;
        cornerPos = player.DetermineCornerPosition();

        startPos.Set(cornerPos.x - (player.FacingDirection * playerData.startOffset.x), cornerPos.y - playerData.startOffset.y);
        stopPos.Set(cornerPos.x + (player.FacingDirection * playerData.stopOffset.x), cornerPos.y + playerData.stopOffset.y);

        //player.transform.position = startPos;
        player.GetComponent<Rigidbody2D>().gravityScale = 0f;
    }

    public override void Exit()
    {
        base.Exit();
        player.GetComponent<Rigidbody2D>().gravityScale = 5f;
        isHanging = false;

        if (isClimbing)
        {
            player.transform.position = stopPos;
            isClimbing = false;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //Top of ledge
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(player.IdleState);
        } else {
            xInput = player.InputHandler.NormInputX;
            yInput = player.InputHandler.NormInputY;

            player.setVelocityZero();
            // player.transform.position = startPos;

            if (xInput == player.FacingDirection && isHanging && !isClimbing)
            {
                //Include if want to ledge climb
                // isClimbing = true;
                // player.Anim.SetBool("climbLedge", true);   
            } else if (yInput == -1 && isHanging && !isClimbing) //Player presses down arrow key
            {
                player.InputHandler.GrabInput = false;
                stateMachine.ChangeState(player.InAirState);
            }
             else if (xInput == -player.FacingDirection && isHanging && !isClimbing) //Player presses the left/right arrow key, opposite to facing direction
            {
                player.InputHandler.GrabInput = false;
                stateMachine.ChangeState(player.InAirState);
            }
        }
    }

    public void SetDetectedPosition(Vector2 pos) => detectedPos = pos;

}