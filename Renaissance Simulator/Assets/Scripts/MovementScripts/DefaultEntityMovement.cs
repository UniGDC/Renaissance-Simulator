using UnityEngine;
using System.Collections;
using UnityEngine.Assertions.Comparers;

public abstract class DefaultEntityMovement : AbstractEntityMovement
{
    private const float DefualtAirborneSpeedMultiplier = 0.25F;
    private const float DefaultJumpForce = 2F;

    public float AirborneForceMultiplier;
    public float JumpForce;

    void Start()
    {
        if (AirborneForceMultiplier < 0)
        {
            AirborneForceMultiplier = DefualtAirborneSpeedMultiplier;
        }
        if (JumpForce < 0)
        {
            JumpForce = DefaultJumpForce;
        }
    }

    protected abstract float GetHorizontalInput();

    protected abstract float GetVerticalInput();

    protected bool IsReversingDirection()
    {
        float HorizontalInput = GetHorizontalInput();
        return (HorizontalInput < 0 && ThisBody.velocity.x > 0) || (HorizontalInput > 0 && ThisBody.velocity.x < 0);
    }

    protected override float GetHorizontalMove()
    {
        return GetHorizontalInput() * HorizontalSpeedCap *
               (!IsGrounded() && IsReversingDirection() ? AirborneForceMultiplier : 1f);
    }

    protected override bool GetJump()
    {
        return IsGrounded() && GetVerticalInput() > 0;
    }

    protected override float GetJumpForce()
    {
        return JumpForce;
    }
}