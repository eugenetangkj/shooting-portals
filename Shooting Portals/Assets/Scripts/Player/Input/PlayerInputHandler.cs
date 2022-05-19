using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool GrabInput { get; private set; }
    public bool AttackShootInput { get; private set;}
    public bool CanShoot { get; private set;}


    private float inputHoldTime = 0.1f;
    private float jumpInputStartTime;
    private float attackShootInputStartTime;

    private void Start()
    {
        CanShoot = true;
    }
    private void Update()
    {
        CheckJumpInputHoldTime();
        CheckAttackShootInputHoldTime();
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
            JumpInput = true;
            jumpInputStartTime = Time.time;
        }
    }

    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if (context.started) //press x button
        {
            GrabInput = true;
        }
        if (context.canceled) //release x button
        {
            GrabInput = false;
        }
    }

    public void OnAttackShootInput(InputAction.CallbackContext context)
    {
        if (context.started && CanShoot) //press 1 button
        {
            AttackShootInput = true;
            CanShoot = false;
            attackShootInputStartTime = Time.time;
            Invoke("changeCanShoot", 1f); //Can only shoot again 1s later
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

    private void CheckAttackShootInputHoldTime()
    {
        if (Time.time >= attackShootInputStartTime + inputHoldTime)
        {
            AttackShootInput = false;
        }
        
    }

    private void changeCanShoot()
    {
        CanShoot = true;
    }
}
