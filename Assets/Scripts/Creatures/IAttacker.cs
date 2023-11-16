using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacker
{
    public int DamageAmount { get; }

    public void Attack(Creature other);

    public void UpgradeDamageAmount(int amount);
}
