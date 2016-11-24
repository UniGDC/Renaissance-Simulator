using UnityEngine;
using System.Collections;

public class PlayerMovement : DefaultEntityMovement
{
    protected override float GetHorizontalInput()
    {
        float RawInput = Input.GetAxisRaw("Horizontal");
        return RawInput > 0 ? 1 : RawInput < 0 ? -1 : 0;
    }

    protected override float GetVerticalInput()
    {
        return Input.GetAxis("Vertical");
    }
}