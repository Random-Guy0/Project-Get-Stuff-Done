public class Animal : Creature, IAttacker, IDefender
{
    private int _damageAmount;
    public int DamageAmount => _damageAmount;

    public Animal(int maxHealth, int damageAmount) : base(maxHealth)
    {
        _damageAmount = damageAmount;
    }

    public void Attack(Creature other)
    {
        other.TakeDamage(DamageAmount);
    }

    public void UpgradeDamageAmount(int amount)
    {
        _damageAmount += amount;
    }

    public void Defend(Creature other)
    {
        other.Protect();
    }
}