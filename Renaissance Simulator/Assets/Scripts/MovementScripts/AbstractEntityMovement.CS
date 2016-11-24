using System.Linq;
using UnityEngine;
using UnityEngineInternal;

public abstract class AbstractEntityMovement : MonoBehaviour
{
    public int[] GroundLayers;
    private int GroundLayerMask = 0;

    public float HorizontalSpeedCap;

    public Rigidbody2D ThisBody;
    public Collider2D ThisCollider;

    protected bool IsGrounded;

    // Use this for initialization
    protected virtual void Start()
    {
        foreach (int layer in GroundLayers)
        {
            GroundLayerMask += 1 << layer;
        }

        if (ThisBody == null)
        {
            ThisBody = gameObject.GetComponent<Rigidbody2D>();
        }
        if (ThisCollider == null)
        {
            ThisCollider = gameObject.GetComponent<Collider2D>();
        }
    }

    protected bool UpdateGrounded()
    {
        IsGrounded = ThisCollider.IsTouchingLayers(GroundLayerMask);
        return IsGrounded;
    }

    /*
    Evaluates the horizontal movement input of the character.
    Returns a number between -1 and 1, which will then be multiplied by the speed field to apply a force to the body.
     */
    protected abstract float GetHorizontalMove();

    /*
    Calculates the jumping force.
     */
    protected abstract float GetJumpForce();

    /*
    Evaluates whether the entity wants to jump right now.
     */
    protected abstract bool GetJump();

    protected virtual void OnJump()
    {
        IsGrounded = false;
    }

    protected virtual void OnLand()
    {
        IsGrounded = true;
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (GroundLayers.Contains(other.gameObject.layer))
        {
            OnLand();
        }
    }

    void FixedUpdate()
    {
        ThisBody.velocity = new Vector2(GetHorizontalMove(), ThisBody.velocity.y);

        if (GetJump())
        {
            ThisBody.AddForce(new Vector2(0, GetJumpForce()), ForceMode2D.Impulse);
            OnJump();
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