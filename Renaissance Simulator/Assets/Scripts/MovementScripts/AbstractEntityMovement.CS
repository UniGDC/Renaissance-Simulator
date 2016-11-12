using UnityEngine;

public abstract class AbstractEntityMovement : MonoBehaviour
{
    public int GroundLayerMask;

    public float HorizontalSpeedCap;

    public Rigidbody2D ThisBody;
    public Collider2D ThisCollider;

	// Use this for initialization
	void Start()
    {

	}

	/*
	Evaluates the horizontal movement input of the character.
	Returns a number between -1 and 1, which will then be multiplied by the speed field to apply a force to the body.
	 */
	protected abstract float GetHorizontalMoveForce();

	/*
	Evaluates whether the entity wants to jump right now.
	 */
	protected abstract bool GetJump();

	/*
	Calculates the jumping force.
	 */
	protected abstract float GetJumpForce();

	protected bool IsGrounded()
	{
		return ThisCollider.IsTouchingLayers(GroundLayerMask);
	}

    void FixedUpdate()
    {
	    ThisBody.AddForce(new Vector2(GetHorizontalMoveForce(), 0));

        if (GetJump())
        {
            ThisBody.AddForce(new Vector2(0, GetJumpForce()), ForceMode2D.Impulse);
        }
    }
	
	// Update is called once per frame
	void Update()
    {
        if (ThisBody.velocity.x > HorizontalSpeedCap)
        {
            ThisBody.velocity = new Vector2(HorizontalSpeedCap, ThisBody.velocity.y);
        }
        else if (ThisBody.velocity.x < -HorizontalSpeedCap)
        {
            ThisBody.velocity = new Vector2(-HorizontalSpeedCap, ThisBody.velocity.y);
        }
    }
}
