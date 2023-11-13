using UnityEngine;

[CreateAssetMenu(menuName = "Creatures/Animal", fileName = "new Animal")]
public class Animal : Creature, IAttacker, IDefender
{
    [SerializeField] private int damageAmount;
    public int DamageAmount => damageAmount;

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
        other.Protect();
    }
}