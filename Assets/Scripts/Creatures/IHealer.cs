using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealer
{
    public int HealAmount { get; }
    
    public void Heal(Creature other);

    public void UpgradeHealAmount(int amount);
}
