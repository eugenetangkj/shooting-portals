using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents the behaviour of the Player
public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine {get; private set;}

    public PlayerIdleState IdleState { get; private set; }

    public PlayerMoveState MoveState { get; private set; }

    public PlayerJumpState JumpState { get; private set; }

    public PlayerInAirState InAirState { get; private set; }

    public PlayerWallGrabState WallGrabState { get; private set; }

    public PlayerWallClimbState WallClimbState { get; private set; }

    public PlayerWallSlideState WallSlideState { get; private set; }

    public PlayerWallJumpState WallJumpState { get; private set; }

    public PlayerLedgeClimbState LedgeClimbState { get; private set; }

    public PlayerAttackShootState AttackShootState { get; private set; }

    public PlayerAttackJumpState AttackJumpState { get; private set; }

    public PlayerPortalShootState PortalShootState { get; private set; }

    public PlayerPortalShootJumpState PortalShootJumpState { get; private set; }

    public PlayerTeleportState TeleportState { get; private set; }

    public PlayerPushState PushState { get; private set; }

    
    [SerializeField] private PlayerData playerData;
    #endregion

    #region Components
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform wallCheck;
    [SerializeField] Transform ledgeCheck;
    
    [SerializeField] Transform firePoint;
    [SerializeField] Transform firePointJump;
    [SerializeField] GameObject attackShot;
    [SerializeField] GameObject portalShot;
    public Rigidbody2D RB { get; private set; }
    #endregion
    
    #region Other Variables
    public Vector2 CurrentVelocity { get; private set; }

    //Left = -1, Right = 1;
    public int FacingDirection { get; private set; }

    public static float[] ShootDirection = new float[2] {0, 0};

    private Vector2 workspace;
    #endregion

    #region Unity Callback Functions

    //Whenever a game starts, create a new StateMachine instance
    //for the player
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "jump");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        WallGrabState = new PlayerWallGrabState(this, StateMachine, playerData, "wallGrab");
        WallClimbState = new PlayerWallClimbState(this, StateMachine, playerData, "wallClimb");
        WallSlideState = new PlayerWallSlideState(this, StateMachine, playerData, "wallSlide");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, playerData, "inAir");
        LedgeClimbState = new PlayerLedgeClimbState(this, StateMachine, playerData, "ledgeClimbState");
        AttackShootState = new PlayerAttackShootState(this, StateMachine, playerData, "attackShot");
        AttackJumpState = new PlayerAttackJumpState(this, StateMachine, playerData, "attackJumpShot");
        PortalShootState = new PlayerPortalShootState(this, StateMachine, playerData, "portalShot");
        PortalShootJumpState = new PlayerPortalShootJumpState(this, StateMachine, playerData, "portalJumpShot");
        TeleportState = new PlayerTeleportState(this, StateMachine, playerData, "teleport");
        PushState = new PlayerPushState(this, StateMachine, playerData, "push");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        FacingDirection = 1;
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        CurrentVelocity = RB.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Set Functions
    public void setVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void setVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x, velocity);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void setVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workspace.Set(angle.x * velocity * direction, angle.y * velocity);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void setVelocityZero()
    {
        RB.velocity = Vector2.zero;
        CurrentVelocity = Vector2.zero;
    }


    #endregion

    #region Check Functions
    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.whatIsGround);       
    }

    public bool CheckIfTouchingWall()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
    }

    public bool CheckIfTouchingWallBack()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * - FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
    }

    public bool CheckIfTouchingLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.right * FacingDirection, playerData.latchCheckDistance, playerData.whatIsGround);
    }



    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
        {
            flip();
        }
    }
    #endregion

    #region Other Functions
    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
    
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
    public void flip()
    {
        FacingDirection  = FacingDirection * -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    public Vector2 DetermineCornerPosition()
    {
        RaycastHit2D xHit = Physics2D.Raycast(wallCheck.position, Vector2.right * FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
        float xDist = xHit.distance; //detect x distance between raycast origin to the detected object/ledge
        workspace.Set((xDist + 0.015f) * FacingDirection, 0);
        RaycastHit2D yHit = Physics2D.Raycast(ledgeCheck.position + (Vector3) (workspace), Vector2.down, ledgeCheck.position.y - wallCheck.position.y + 0.015f, playerData.whatIsGround);
        float yDist = yHit.distance;
        
        workspace.Set(wallCheck.position.x + (xDist * FacingDirection), ledgeCheck.position.y - yDist);
        return workspace;
    }

    public void ShootAttack()
    {
        Invoke("createAttackShot", 0.2f);
    }

    public void PortalShootAttack()
    {

        Invoke("createPortalShot", 0.3f);
        if (ShootDirection[0] == 0 && ShootDirection[1] == 0)
        {
            ShootDirection[0] = (this.transform.rotation.y >= 0 && this.transform.rotation.y < 0.1f) ? 1 : -1;
            Debug.Log(ShootDirection[0]);
        } else if (ShootDirection[1] == 0)
        {
            ShootDirection[1] = (this.transform.rotation.y >= 0 && this.transform.rotation.y < 0.1f) ? 1 : -1;
            Debug.Log(ShootDirection[1]);
        } else {
            ShootDirection[0] = ShootDirection[1];
            Debug.Log(this.transform.rotation.y);
            ShootDirection[1] = (this.transform.rotation.y >= 0 && this.transform.rotation.y < 0.1f) ? 1 : -1;
            Debug.Log(ShootDirection[0]);
            Debug.Log(ShootDirection[1]);
        }
    }

    private void createAttackShot()
    {
        Instantiate(attackShot, firePoint.position, firePoint.rotation);
    }
    private void createPortalShot()
    {
        Instantiate(portalShot, firePoint.position, firePoint.rotation);
    }

    //Jump
    public void ShootJumpAttack()
    {
        Invoke("createAttackJumpShot", 0.2f);
    }

    public void PortalShootJumpAttack()
    {
        Invoke("createPortalJumpShot", 0.3f);
        if (ShootDirection[0] == 0 && ShootDirection[1] == 0)
        {
            ShootDirection[0] = (this.transform.rotation.y > 0 && this.transform.rotation.y < 0.1f) ? 1 : -1;
        } else if (ShootDirection[1] == 0)
        {
            ShootDirection[1] = (this.transform.rotation.y > 0 && this.transform.rotation.y < 0.1f) ? 1 : -1;
        } else {
            ShootDirection[0] = ShootDirection[1];
            ShootDirection[1] = (this.transform.rotation.y > 0 && this.transform.rotation.y < 0.1f) ? 1 : -1;
        }
    }

    private void createAttackJumpShot()
    {
        Instantiate(attackShot, firePointJump.position, firePointJump.rotation);
    }
    private void createPortalJumpShot()
    {
        Instantiate(portalShot, firePointJump.position, firePointJump.rotation);
    }

    //Prevents player from moving
    private void freezePosition()
    {
        RB.constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    //Allows player to move again
    private void unfreezePositions()
    {
        RB.constraints = RigidbodyConstraints2D.None;
        RB.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    
    #endregion
}
