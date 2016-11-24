using System;
using UnityEngine;

public abstract class DefaultEntityMovement : AbstractEntityMovement
{
    private const float DefualtAirborneSpeedMultiplier = 0.25F;
    private const float DefaultJumpForce = 2F;

    public float AirborneSpeedMultiplier;
    public float JumpForce;

    protected float JumpLaunchDirection;

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
    }

    protected abstract float GetHorizontalInput();

    protected abstract float GetVerticalInput();

    protected override float GetHorizontalMove()
    {
        return GetHorizontalInput() * HorizontalSpeedCap *
               (IsReversingDirection() ? AirborneSpeedMultiplier : 1f);
    }

    protected override float GetJumpForce()
    {
        return JumpForce;
    }

    protected override bool GetJump()
    {
        return IsGrounded() && GetVerticalInput() > 0;
    }

    protected bool IsReversingDirection()
    {
        float HorizontalInput = GetHorizontalInput();
        return !IsGrounded() &&
               ((HorizontalInput < 0 && JumpLaunchDirection > 0) || (HorizontalInput > 0 && JumpLaunchDirection < 0));
    }

    protected override void OnJump()
    {
        base.OnJump();
        JumpLaunchDirection = ThisBody.velocity.x;
    }
}