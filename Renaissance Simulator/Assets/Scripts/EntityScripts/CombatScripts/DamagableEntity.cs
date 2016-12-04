using System;
using UnityEngine;
using System.Collections;

public class DamagableEntity : MonoBehaviour
{
    private const int DefaultMaxHealth = 100;
    public int MaxHealth;
    public int DamageReduction;
    private int _health;

    public delegate void DeathAction(GameObject gameObject);

    /// <summary>
    /// The script that handles death behaviour.
    /// <br />
    /// It is a function that takes one GameObject parameter, which is the game object that is dying.
    /// </summary>
    public DeathAction OnDeath;

    private void DefaultDeathAction(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        // Initialize to default values if needed.
        if (MaxHealth <= 0)
        {
            MaxHealth = DefaultMaxHealth;
        }
        _health = MaxHealth;

        if (OnDeath == null)
        {
            OnDeath = DefaultDeathAction;
        }
    }

    /// <summary>
    /// Directly damages the character's health pool, ignores all delegate calculations.
    /// </summary>
    /// <param name="change">The amount of health points to take away</param>
    public void ChangeHealth(int change)
    {
        _health += change;
        print(_health);

        if (_health < 0)
        {
            OnDeath(gameObject);
        }
    }

    /// <summary>
    /// Damages the entity.
    /// <br />
    /// All functions overriding ApplyDamage should use ChangeHealth to change the health of the character.
    /// </summary>
    /// <param name="damageStrength">The strength of the damage</param>
    public virtual void ApplyDamage(int damageStrength)
    {
        int actualDamage = damageStrength - DamageReduction;
        ChangeHealth(actualDamage < 0 ? 0 : actualDamage);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public int Health
    {
        get { return _health; }
    }
}