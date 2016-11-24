using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{
	// The speed relative to player; set this to 0 to stay stationary, 1 to follow the player, and anywhere in between to move slower than the player.
    public float ParallaxFactor;
    public bool Late;
    public GameObject Player;
    float PlayerInitialX;
    float ObjectInitialX;

    // Use this for initialization
    void Start()
    {
    }

    void Awake()
    {
        PlayerInitialX = Player.transform.position.x;
        ObjectInitialX = gameObject.transform.position.x;
    }

    void UpdatePosition()
    {
        gameObject.transform.position =
            new Vector3(ObjectInitialX + (Player.transform.position.x - PlayerInitialX) * ParallaxFactor,
                gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Late)
        {
            UpdatePosition();
        }
    }

    void LateUpdate()
    {
        if (Late)
        {
            UpdatePosition();
        }
    }
}