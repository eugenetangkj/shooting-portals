using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is the parent class of all the different player states. Since it will not be attached
//to any GameObject, it will not extend MonoBehaviour.
public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;

    //protected bool isAnimationFinished;

    //Start time gets initialized everytime we enter a player state, hence we can track how long we enter that state
    protected float startTime;
    //The animation to run for this state
    private string animBoolName;

    //Constructor
    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    //Virtual means this method can be overriden by inheriting classes

    //Gets called when we enter a state
    public virtual void Enter()
    {
        DoChecks();
        player.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
        //isAnimationFinished = false;

    }

    //Gets called when we exit a state
    public virtual void Exit()
    {
        player.Anim.SetBool(animBoolName, false);

    }

    //Gets called every frame, dealing with logic
    public virtual void LogicUpdate()
    {

    }

    //Gets called every fixed frame, dealing with physics
    public virtual void PhysicsUpdate()
    {
        DoChecks();

    }

    //Gets called in Enter and PhysicsUpdate, doing ground
    //and wall checks etc.
    public virtual void DoChecks()
    {

    }

    // public virtual void AnimationTrigger() {

    // }

    // public virtual void AnimationFinishTrigger() => isAnimationFinished = true;


}
