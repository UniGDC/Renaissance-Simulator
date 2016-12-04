using UnityEngine;
using System.Collections;

public class PlayerMovement : DefaultEntityMovement
{
    protected override float GetHorizontalInput()
    {
        float rawInput = Input.GetAxisRaw("Horizontal");
        return rawInput > 0 ? 1 : rawInput < 0 ? -1 : 0;
    }

    protected override float GetVerticalInput()
    {
        return Input.GetAxis("Vertical");
    }
}