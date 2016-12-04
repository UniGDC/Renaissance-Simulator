using UnityEngine;
using System.Collections;

public class FireControllerScript : MonoBehaviour
{
    public GameObject Player;

    public float StartPoint;
    public float PropagationSpeed;
    private float _currentFront;

    public float Damage;
    /// <summary>
    /// Above this y level the player does not take damage
    /// </summary>
    public float YThreshold;

    // Use this for initialization
    void Start()
    {
        _currentFront = StartPoint;
    }

    // Update is called once per frame
    void Update()
    {
        _currentFront += PropagationSpeed * Time.deltaTime;

        // Null check
        if (Player == null || Player.transform == null) return;

        // Damage the player if it is too close
        Vector2 playerPosition = Player.transform.position;
        // print(playerDistance);

        if (playerPosition.x < _currentFront && playerPosition.y < YThreshold)
        {
            Player.GetComponent<DamagableEntity>().ChangeHealth(-Damage);
        }
    }
}