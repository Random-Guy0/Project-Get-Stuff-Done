using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature
{
    public int Health { get; private set; }
    private int _maxHealth;
    
    public bool Defended { get; private set; }

    public Creature(int maxHealth)
    {
        Health = maxHealth;
        _maxHealth = Health;
    }

    public void TakeDamage(int amount)
    {
        if (Defended)
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

        if (Health > _maxHealth)
        {
            Health = _maxHealth;
        }
    }

    public void Die()
    {
        
    }

    public void UpgradeHealth(int amount)
    {
        Health += amount;
        _maxHealth += amount;
    }

    public void Protect()
    {
        Defended = true;
    }
}
