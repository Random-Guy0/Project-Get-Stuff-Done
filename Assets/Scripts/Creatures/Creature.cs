using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Creature : ScriptableObject
{
    [field: SerializeField] public int CostOrScore { get; private set; }

    private int _health;

    public int Health
    {
        get => _health;
        private set
        {
            _health = value;
            OnHealthChanged?.Invoke(value);
        }
    }

    public delegate void OnHealthChangedHandler(int health);
    public event OnHealthChangedHandler OnHealthChanged;
    
    [SerializeField] private int maxHealth;

    public delegate void OnDeathHandler();

    public event OnDeathHandler OnDeath;

    private int _shield;
    public int Shield
    {
        get => _shield;
        private set
        {
            _shield = value;
            OnShieldChanged?.Invoke(value);
        }
    }
    
    public delegate void OnShieldChangedHandler(int shield);
    public event OnShieldChangedHandler OnShieldChanged;
    
    public bool HasAttacked { get; set; }

    public virtual void Init()
    {
        Health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        int newDefense = Shield - amount;
        if (newDefense < 0)
        {
            newDefense = 0;
        }
        
        amount -= Shield;
        Shield = amount;
        if (amount <= 0)
        {
            return;
        }
        
        Health -= amount;
        if (Health <= 0)
        {
            Health = 0;
            Die();
        }
    }

    public void Heal(int amount)
    {
        Health += amount;

        if (Health > maxHealth)
        {
            Health = maxHealth;
        }
    }

    public void Die()
    {
        OnDeath?.Invoke();
    }

    public void UpgradeHealth(int amount)
    {
        Health += amount;
        maxHealth += amount;
    }

    public void Protect(int amount)
    {
        Shield = amount;
    }
}
