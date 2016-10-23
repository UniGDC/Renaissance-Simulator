using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour
{
    public float HorizontalSpeed;
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

        if (ThisCollider.IsTouchingLayers() && Input.GetAxis("Vertical") > 0)
        {
            ThisBody.AddForce(new Vector2(VerticalSpeed, 0), ForceMode2D.Impulse);
        }
    }
	
	// Update is called once per frame
	void Update()
    {
	    
	}
}
