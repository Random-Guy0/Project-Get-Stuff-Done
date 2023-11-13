public class Crop : Creature, IDefender, IHealer
{
    private int _healAmount;
    public int HealAmount => _healAmount;
    
    public Crop(int maxHealth, int healAmount) : base(maxHealth)
    {
        _healAmount = healAmount;
    }

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
        _healAmount += amount;
    }
}