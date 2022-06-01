using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class contains the data associated with the player,
//such as jump force and movement speed.
[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10f;

    [Header("Jump State")]
    public float jumpVelocity = 15f;

    [Header("Wall Slide State")]
    public float wallSlideVelocity = 3f;

    [Header("Wall Climb State")]
    public float wallClimbVelocity = 3f;

    [Header("Wall Jump State")]
    public float wallJumpVelocity = 20f;
    public float wallJumpTime = 0.4f; //make us stay in wall jump state for a period of time, preventing us from immediately jumping back to the same wall
    public Vector2 wallJumpAngle = new Vector2(1, 2);

    [Header("Ledge Climb State")]
    public Vector2 startOffset;
    public Vector2 stopOffset;

    [Header("Portal Shoot")]
    public float portalShootOffset = 2.3f;



    [Header("Check Variables")]
    public float groundCheckRadius = 0.3f;
    public float wallCheckDistance = 0.5f;
    public float latchCheckDistance = 0.8f;
    public float movableCheckDistance = 0.5f;
    public float movableCheckWallDistance = 1.0f;
    public float groundLedgeCheckDistance = 0.5f;
    public LayerMask whatIsGround;
    public LayerMask whatIsMovable;



}
