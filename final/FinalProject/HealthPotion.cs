using System;

public class HealthPotion : Item
{
    public int HealAmount { get; }

    public HealthPotion(string name, string description, int value, int healAmount)
        : base(name, description, value)
    {
        HealAmount = healAmount;
    }

    public override void Use(Player player)
    {
        int missing = player.MaxHealth - player.Health;
        if (missing <= 0)
        {
            Console.WriteLine($"{player.Name} is already at full health. The {Name} has no effect.");
            return;
        }

        int amountToHeal = Math.Min(HealAmount, missing);

        // Assumes Player (or Character) has a Heal(int amount) method.
        player.Heal(amountToHeal);

        Console.WriteLine($"{player.Name} drinks {Name} and recovers {amountToHeal} HP!");
    }
}
