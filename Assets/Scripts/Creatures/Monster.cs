using UnityEngine;

[CreateAssetMenu(menuName = "Creatures/Monster", fileName = "new Monster")]
public class Monster : Creature, IAttacker, IDefender
{
    [field: SerializeField] public MonsterContainer Prefab { get; private set; }
    
    [SerializeField] private int damageAmount;
    public int DamageAmount => damageAmount;
    
    [SerializeField] private int defenseAmount;
    public int DefenseAmount => defenseAmount;

    public void Attack(Creature other)
    {
        other.TakeDamage(DamageAmount);
    }

    public void UpgradeDamageAmount(int amount)
    {
        damageAmount += amount;
    }

    public void Defend(Creature other)
    {
        other.Protect(DefenseAmount);
    }

    public void UpgradeDefenseAmount(int amount)
    {
        defenseAmount += amount;
    }
}