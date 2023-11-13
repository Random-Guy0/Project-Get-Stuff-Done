using UnityEngine;

[CreateAssetMenu(menuName = "Creatures/Crop", fileName = "new Crop")]
public class Crop : Creature, IDefender, IHealer
{
    [SerializeField] private int healAmount;
    public int HealAmount => healAmount;

    public void Defend(Creature other)
    {
        other.Protect();
    }

    
    public void Heal(Creature other)
    {
        other.Heal(HealAmount);
    }

    public void UpgradeHealAmount(int amount)
    {
        healAmount += amount;
    }
}