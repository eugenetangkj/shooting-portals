using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


//This class handles the input that will control the Player prefab in game.
public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private Player player;

    #region Input Variables
    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool GrabInput { get; set; }
    public bool AttackShootInput { get; private set; }
    public bool PushInput { get; set; }
    public bool CanShoot { get; private set; }
    public bool PortalShootInput { get; private set; }
    public bool CanPortalShoot { get; private set; }
    public bool TeleportInput { get; private set; }
    public bool CanTeleport { get; private set; }
    #endregion

    #region Input Time Variables
    private float inputHoldTime = 0.05f;
    private float jumpInputStartTime;
    private float attackShootInputStartTime;
    private float portalShootInputStartTime;
    #endregion

    #region Main Functions
    private void Start()
    {
        CanShoot = true;
        CanPortalShoot = true;
        GrabInput = false;
        PushInput = false;
    }
    private void Update()
    {
        CheckJumpInputHoldTime();
        CheckAttackShootInputHoldTime();
        CheckPortalShootInputHoldTime();
        CanTeleport = player.CheckIfTouchingPortal() && Portal.checkGotTwoPortals();
        //Debug.Log(Portal.portalCount);
    }
    #endregion

    #region Input Functions

    //Handles movement input when user presses arrow keys
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (! PauseMenu.isGamePaused && ! player.haveCompletedLevel && ! player.InputHandler.TeleportInput)
        {
        RawMovementInput = context.ReadValue<Vector2>();
        NormInputX = (int) (RawMovementInput * Vector2.right).normalized.x; //if vector's x component is 0, normalize returns zero vector, otherwise returns an unit vector
        NormInputY = (int) (RawMovementInput * Vector2.up).normalized.y;
        } else {
            NormInputX = 0;
            NormInputY = 0;
        }
    }

    //Handles jump input when user presses space
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started && ! PauseMenu.isGamePaused && ! player.haveCompletedLevel) //press jump button
        {
            GrabInput = false;
            JumpInput = true;
            jumpInputStartTime = Time.time;
        }
    }

    //Handles grab input when user presses z
    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if (context.started && ! PauseMenu.isGamePaused && ! player.haveCompletedLevel) //press z button
        {
            if (player.CheckIfTouchingWall())
            {
            GrabInput = (GrabInput == true) ? false : true;
            }
        }
        // if (context.canceled) //release z button
        // {
        //     GrabInput = false;
        // }
    }

    //Handles attack input when user presses c
    public void OnAttackShootInput(InputAction.CallbackContext context)
    {
        if (context.started && CanShoot && CanPortalShoot &&
            ! PauseMenu.isGamePaused && ! player.haveCompletedLevel && (PlayerfabLoad.getPlayerLevelAfter() >= 2)) //press c button, && (PlayerfabLoad.getPlayerLevelAfter() >= 2)
        {
            AttackShootInput = true;
            CanShoot = false;
            attackShootInputStartTime = Time.time;
            Invoke("changeCanShoot", 1f); //Can only shoot again 1s later
        }
    }

    //Handles portal shoot input when user presses v
    public void OnPortalShootInput(InputAction.CallbackContext context)
    {
        if (context.started && CanShoot && CanPortalShoot
            && ! PauseMenu.isGamePaused && ! player.haveCompletedLevel && (PlayerfabLoad.getPlayerLevelAfter() >= 2)) //press v button, (PlayerfabLoad.getPlayerLevelAfter() >= 2)
        {
            Player.playerShootDirection = player.transform.rotation.y;
            PortalShootInput = true;
            CanPortalShoot = false;
            portalShootInputStartTime = Time.time;
            Invoke("changeCanPortalShoot", 1f); //Can only shoot again 2.5s later
        }
    }

    //Handles teleport input when user presses up arrow key
    public void OnTeleportInput(InputAction.CallbackContext context)
    {
        if (context.started && CanTeleport && (Portal.portalCount == 2)
            && ! PauseMenu.isGamePaused && ! player.haveCompletedLevel && (PlayerfabLoad.getPlayerLevelAfter() >= 2) ) //press up button, && (PlayerfabLoad.getPlayerLevelAfter() >= 2)
        {
            if (player.isInPushState && Portal.gotBlock)
            {
            }
            else {
            TeleportInput = true;
            }
        }
        if (context.canceled) // release up button
        {
            TeleportInput = false;
        }
    }

    //Handles destroy portals input when user presses b
    public void OnDestroyAllPortalsInput(InputAction.CallbackContext context)
    {
        if (context.started && ! PauseMenu.isGamePaused && ! player.haveCompletedLevel && (PlayerfabLoad.getPlayerLevelAfter() >= 2)) //press b, && (PlayerfabLoad.getPlayerLevelAfter() >= 2)
        {
            player.destroyPortalSound.Play();
            Portal.destroyAllPortals();
        }
    }


    //Handles push input when user presses x
    public void OnPushInput(InputAction.CallbackContext context)
    {
        if (context.started && ! PauseMenu.isGamePaused && ! player.haveCompletedLevel && ! player.InputHandler.TeleportInput) //press x
        {
            // Debug.Log("Push State: " + player.isInPushState);
            // Debug.Log("Grounded: " + player.CheckIfGrounded());
            if ((player.isInPushState || player.CheckIfTouchingMovable()) && player.CheckIfGrounded())
            {
                PushInput = (PushInput == true) ? false : true;
            }
        }
    }

    #endregion

    #region Use Input Functions

    //Consumes jump input
    public void UseJumpInput() => JumpInput = false;

    //Consumes attack input
    public void UseAttackShootInput() => AttackShootInput = false;

    //Consumes portal shoot input
    public void UsePortalShootInput() => PortalShootInput = false;

    //Consumes teleport input
    public void UseTeleportInput() => TeleportInput = false;

    //Consumes push input
    public void UsePushInput() => TeleportInput = false;


    #endregion

    #region Check Input Hold Time Functions

    //Holds jump input true for a short period of time when user input is detected, setting it false thereafter
    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }

    //Holds attack shoot input true for a short period of time when user input is detected, setting it false thereafter
    private void CheckAttackShootInputHoldTime()
    {
        if (Time.time >= attackShootInputStartTime + inputHoldTime)
        {
            AttackShootInput = false;
        }
        
    }

    //Holds portal shoot input true for a short period of time when user input is detected, setting it false thereafter
    private void CheckPortalShootInputHoldTime()
    {
        if (Time.time >= portalShootInputStartTime + inputHoldTime)
        {
            PortalShootInput = false;
        }
        
    }
    #endregion

    #region Shoot Functions

    //Allow for player to attack shoot
    private void changeCanShoot()
    {
        CanShoot = true;
    }

    //Allow for player to portal shoot
    private void changeCanPortalShoot()
    {
        CanPortalShoot = true;
    }
    #endregion

}