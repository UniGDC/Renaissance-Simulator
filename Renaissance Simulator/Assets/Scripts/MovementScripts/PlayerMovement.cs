using UnityEngine;
using System.Collections;

public class PlayerMovement : DefaultEntityMovement
{
    protected override float GetHorizontalInput()
    {
        return Input.GetAxis("Horizontal");
    }

    protected override float GetVerticalInput()
    {
        return Input.GetAxis("Vertical");
    }
}