using UnityEngine;
using System.Collections;

public class FireControllerScript : MonoBehaviour
{
    public GameObject Player;

    public float StartPoint;
    public float PropagationSpeed;
    private float _currentFront;

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
        float playerDistance = playerPosition.x + playerPosition.y - _currentFront;
        // print(playerDistance);

        if (playerDistance > 0)
        {
            return;
        }
        if (Player.GetComponent<AbstractEntityMovement>().Grounded)
        {
            if (playerDistance > -5)
            {
                Player.GetComponent<DamagableEntity>().ChangeHealth((int) playerDistance);
            }
            else
            {
                Player.GetComponent<DamagableEntity>().ChangeHealth(-5);
            }
        }
    }
}