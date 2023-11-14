using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Creature : ScriptableObject
{
    [field: SerializeField] public int Cost { get; private set; }
    
    public int Health { get; private set; }
    [SerializeField] private int maxHealth;
    
    public int Defense { get; private set; }

    public virtual void Init()
    {
        Health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        int newDefense = Defense - amount;
        if (newDefense < 0)
        {
            newDefense = 0;
        }
        
        amount -= Defense;
        Defense = amount;
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
        
    }

    public void UpgradeHealth(int amount)
    {
        Health += amount;
        maxHealth += amount;
    }

    public void Protect(int amount)
    {
        Defense = amount;
    }
}
