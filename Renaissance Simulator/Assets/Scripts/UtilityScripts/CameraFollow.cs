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

    // Update is called once per frame
    void LateUpdate()
    {
        // Null check
        if (PlayerTransform == null) return;

        ThisTransform.position =
            new Vector3(Bounded ? Mathf.Clamp(PlayerTransform.position.x, LeftBound, RightBound) : PlayerTransform.position.x,
                ThisTransform.position.y, ThisTransform.position.z);
    }
}