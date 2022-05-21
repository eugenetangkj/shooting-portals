using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPushState : PlayerGroundedState
{
    public PlayerPushState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
}
