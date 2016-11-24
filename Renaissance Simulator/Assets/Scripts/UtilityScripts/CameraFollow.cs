using UnityEngine;
using System.Collections;
using UnityEngine.Assertions.Comparers;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    private Transform ThisTransform;
    private Transform PlayerTransform;

    public bool Bounded;
    public float LeftBound;
    public float RightBound;

    // Use this for initialization
    void Start()
    {
        ThisTransform = gameObject.transform;
        PlayerTransform = Player.transform;
    }

    private float Clamp(float Value, float LowerBound, float UpperBound)
    {
        if (Value < LowerBound)
        {
            return LowerBound;
        }
        if (Value > UpperBound)
        {
            return UpperBound;
        }
        return Value;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ThisTransform.position =
            new Vector3(Bounded ? Clamp(PlayerTransform.position.x, LeftBound, RightBound) : PlayerTransform.position.x,
                ThisTransform.position.y, ThisTransform.position.z);
    }
}