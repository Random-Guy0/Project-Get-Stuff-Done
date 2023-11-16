using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDefender
{
    public int DefenseAmount { get; }
    
    public void Defend(Creature other);
    
    public void UpgradeDefenseAmount(int amount);
}
