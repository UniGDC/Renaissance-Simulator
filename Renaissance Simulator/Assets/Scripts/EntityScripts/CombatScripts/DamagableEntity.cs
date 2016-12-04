using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamagableEntity : MonoBehaviour
{
    private const float DefaultMaxHealth = 10;
    public float MaxHealth;
    public float DamageReduction;
    private float _health;

    public Slider HealthBar;

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

        if (HealthBar == null)
        {
            HealthBar = gameObject.GetComponentInChildren<Slider>();
        }

        if (OnDeath == null)
        {
            OnDeath = DefaultDeathAction;
        }

        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        if (HealthBar != null)
        {
            float healthProportion = _health / (float) MaxHealth;
            HealthBar.value = HealthBar.maxValue * healthProportion + HealthBar.minValue * (1 - healthProportion);
        }
    }

    /// <summary>
    /// Directly damages the character's health pool, ignores all delegate calculations.
    /// </summary>
    /// <param name="change">The amount of health points to take away</param>
    public void ChangeHealth(float change)
    {
        _health += change;
        // print(_health);

        // Check for death
        if (_health < 0)
        {
            OnDeath(gameObject);
        }

        UpdateHealthBar();
    }

    /// <summary>
    /// Damages the entity.
    /// <br />
    /// All functions overriding ApplyDamage should use ChangeHealth to change the health of the character.
    /// </summary>
    /// <param name="damageStrength">The strength of the damage</param>
    public virtual void ApplyDamage(float damageStrength)
    {
        float actualDamage = damageStrength - DamageReduction;
        ChangeHealth(actualDamage < 0 ? 0 : actualDamage);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public float Health
    {
        get { return _health; }
    }
}