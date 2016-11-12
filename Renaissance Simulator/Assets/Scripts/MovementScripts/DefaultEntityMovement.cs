using UnityEngine;
using System.Collections;
using UnityEngine.Assertions.Comparers;

public abstract class DefaultEntityMovement : AbstractEntityMovement
{
	private const float DefualtHorizontalSpeed = 10F;
	private const float DefualtAirborneForceMultiplier = 0.25F;
	private const float DefaultJumpForce = 2F;

	public float HorizontalSpeed;
	public float AirborneForceMultiplier;
	public float JumpForce;

	void Start()
	{
		// Check for negative values and reset to defaults.
		if (HorizontalSpeed < 0)
		{
			HorizontalSpeed = DefualtHorizontalSpeed;
		}
		if (AirborneForceMultiplier < 0)
		{
			AirborneForceMultiplier = DefualtAirborneForceMultiplier;
		}
		if (JumpForce < 0)
		{
			JumpForce = DefaultJumpForce;
		}
	}

	protected abstract float GetHorizontalInput();

	protected abstract float GetVerticalInput();

	protected override float GetHorizontalMoveForce()
	{
		return GetHorizontalInput() * HorizontalSpeed * (IsGrounded() ? 1f : AirborneForceMultiplier);
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