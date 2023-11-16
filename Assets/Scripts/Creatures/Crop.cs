using UnityEngine;

[CreateAssetMenu(menuName = "Creatures/Crop", fileName = "new Crop")]
public class Crop : Creature, IDefender, IHealer
{
    [field: SerializeField] public CropContainer Prefab { get; private set; }
    [field: SerializeField] public UpgradeUI UpgradeScreen { get; private set; }
    [SerializeField] private int healAmount;
    public int HealAmount => healAmount;

    [SerializeField] private int defenseAmount;
    public int DefenseAmount => defenseAmount;

    public void Defend(Creature other)
    {
        other.Protect(DefenseAmount);
    }

    public void UpgradeDefenseAmount(int amount)
    {
        defenseAmount += amount;
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