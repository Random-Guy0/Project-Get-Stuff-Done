using UnityEngine;

[CreateAssetMenu(menuName = "Creatures/Animal", fileName = "new Animal")]
public class Animal : Creature, IAttacker, IDefender
{
    [field: SerializeField] public AnimalContainer Prefab { get; private set; }
    [field: SerializeField] public UpgradeUI UpgradeScreen { get; private set; }
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