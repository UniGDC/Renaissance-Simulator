using System;
using UnityEngine;

public abstract class DefaultEntityMovement : AbstractEntityMovement
{
    private const float DefualtAirborneSpeedMultiplier = 0.25F;
    private const float DefaultJumpForce = 2F;

    public float AirborneSpeedMultiplier;
    public float JumpForce;

    protected float JumpLaunchDirection;
    protected bool ReversedDirection;

    protected new virtual void Start()
    {
        base.Start();

        if (AirborneSpeedMultiplier < 0)
        {
            AirborneSpeedMultiplier = DefualtAirborneSpeedMultiplier;
        }
        if (JumpForce < 0)
        {
            JumpForce = DefaultJumpForce;
        }

        JumpLaunchDirection = 0;
        ReversedDirection = false;
    }

    protected abstract float GetHorizontalInput();

    protected abstract float GetVerticalInput();

    protected override float GetHorizontalMove()
    {
        UpdateReversedDirection();
        return GetHorizontalInput() * HorizontalSpeedCap *
               (ReversedDirection ? AirborneSpeedMultiplier : 1f);
    }

    protected override float GetJumpForce()
    {
        return JumpForce;
    }

    protected override bool GetJump()
    {
        return IsGrounded && GetVerticalInput() > 0 && UpdateGrounded();
    }

    protected void UpdateReversedDirection()
    {
        float horizontalInput = GetHorizontalInput();
        bool isReversingDirection = !IsGrounded &&
               ((horizontalInput < 0 && JumpLaunchDirection > 0) || (horizontalInput > 0 && JumpLaunchDirection < 0));
        if (!IsGrounded && isReversingDirection)
        {
            ReversedDirection = true;
        }
    }

    protected override void OnJump()
    {
        base.OnJump();
        JumpLaunchDirection = ThisBody.velocity.x;
    }

    protected override void OnLand()
    {
        base.OnLand();
        ReversedDirection = false;
    }
}