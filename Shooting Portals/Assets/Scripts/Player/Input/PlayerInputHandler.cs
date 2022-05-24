using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private Player player;

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



    private float inputHoldTime = 0.1f;
    private float jumpInputStartTime;
    private float attackShootInputStartTime;
    private float portalShootInputStartTime;

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
        CanTeleport = Portal.inContactWithPlayer;
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
        NormInputX = (int) (RawMovementInput * Vector2.right).normalized.x; //if vector's x component is 0, normalize returns zero vector, otherwise returns an unit vector
        NormInputY = (int) (RawMovementInput * Vector2.up).normalized.y;
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started) //press jump button
        {
            GrabInput = false;
            JumpInput = true;
            jumpInputStartTime = Time.time;
        }
    }

    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if (context.started) //press z button
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

    public void OnAttackShootInput(InputAction.CallbackContext context)
    {
        if (context.started && CanShoot && (PlayerfabLoad.getPlayerLevelAfter() >= 2)) //press 1 button
        {
            AttackShootInput = true;
            CanShoot = false;
            attackShootInputStartTime = Time.time;
            Invoke("changeCanShoot", 1.5f); //Can only shoot again 1.5s later
        }
    }


    public void OnPortalShootInput(InputAction.CallbackContext context)
    {
        if (context.started && CanPortalShoot && (PlayerfabLoad.getPlayerLevelAfter() >= 2)) //press 2 button
        {
            PortalShootInput = true;
            CanPortalShoot = false;
            portalShootInputStartTime = Time.time;
            Invoke("changeCanPortalShoot", 2.5f); //Can only shoot again 2.5s later
        }
    }

    public void OnTeleportInput(InputAction.CallbackContext context)
    {
        if (context.started && CanTeleport && (Portal.portalCount == 2) && (PlayerfabLoad.getPlayerLevelAfter() >= 2)) //press up button
        {
            TeleportInput = true;
        }
        if (context.canceled) // release up button
        {
            TeleportInput = false;
        }
    }

    public void OnDestroyAllPortalsInput(InputAction.CallbackContext context)
    {
        if (context.started && (PlayerfabLoad.getPlayerLevelAfter() >= 2)) //press d
        {
            Portal.destroyAllPortals();
        }
    }

    public void OnPushInput(InputAction.CallbackContext context)
    {
        if (context.started) //press x
        {
            // Debug.Log("Push State: " + player.isInPushState);
            // Debug.Log("Grounded: " + player.CheckIfGrounded());
            if ((player.isInPushState || player.CheckIfTouchingMovable()) && player.CheckIfGrounded())
            {
                // Debug.Log("reached");
                PushInput = (PushInput == true) ? false : true;
            }
        }
    }









    public void UseJumpInput() => JumpInput = false;

    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }

    public void UseAttackShootInput() => AttackShootInput = false;

    public void UsePortalShootInput() => PortalShootInput = false;

    public void UseTeleportInput() => TeleportInput = false;

    public void UsePushInput() => TeleportInput = false;



    private void CheckAttackShootInputHoldTime()
    {
        if (Time.time >= attackShootInputStartTime + inputHoldTime)
        {
            AttackShootInput = false;
        }
        
    }

    private void CheckPortalShootInputHoldTime()
    {
        if (Time.time >= portalShootInputStartTime + inputHoldTime)
        {
            PortalShootInput = false;
        }
        
    }

    private void changeCanShoot()
    {
        CanShoot = true;
    }

    private void changeCanPortalShoot()
    {
        CanPortalShoot = true;
    }
}
