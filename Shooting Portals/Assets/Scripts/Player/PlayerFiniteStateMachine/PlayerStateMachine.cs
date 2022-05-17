using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a state machine for player movement
public class PlayerStateMachine
{
    //Creates a public getter and a private setter
    //for this variable CurrentState
    public PlayerState CurrentState {get; private set;}

    //Initializes and enters the first state
    public void Initialize(PlayerState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    //Changes to and enters the next state
    public void ChangeState(PlayerState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
    
}
