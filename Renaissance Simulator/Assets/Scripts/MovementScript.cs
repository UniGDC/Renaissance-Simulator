using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour
{
    public float HorizontalSpeed;
    public float SpeedCap;
    public float VerticalSpeed;

    public Rigidbody2D ThisBody;
    public Collider2D ThisCollider;
    public Collider2D GroundCollider;

	// Use this for initialization
	void Start()
    {
	
	}

    void FixedUpdate()
    {
        ThisBody.AddForce(new Vector2(Input.GetAxis("Horizontal") * HorizontalSpeed, 0));

        if (ThisCollider.IsTouchingLayers(1 << 9) && Input.GetAxis("Vertical") > 0)
        {
            ThisBody.AddForce(new Vector2(0, VerticalSpeed), ForceMode2D.Impulse);
        }

        if (ThisBody.velocity.x > SpeedCap)
        {
            ThisBody.velocity = new Vector2(SpeedCap, ThisBody.velocity.y);
        }
        else if (ThisBody.velocity.x < -SpeedCap)
        {
            ThisBody.velocity = new Vector2(-SpeedCap, ThisBody.velocity.y);
        }
    }
	
	// Update is called once per frame
	void Update()
    {
	    
	}
}
