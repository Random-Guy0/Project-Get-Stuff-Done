using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Creature : ScriptableObject
{
    public int Health { get; private set; }
    [SerializeField] private int maxHealth;
    
    public bool Defended { get; private set; }

    public virtual void Init()
    {
        Health = maxHealth;
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

        if (Health > maxHealth)
        {
            Health = maxHealth;
        }
    }

    public void Die()
    {
        
    }

    public void UpgradeHealth(int amount)
    {
        Health += amount;
        maxHealth += amount;
    }

    public void Protect()
    {
        Defended = true;
    }
}
