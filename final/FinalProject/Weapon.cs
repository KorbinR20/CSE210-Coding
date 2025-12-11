using System;

public class Weapon : Item
{
    public int AttackBonus { get; }

    public Weapon(string name, string description, int value, int attackBonus)
        : base(name, description, value)
    {
        AttackBonus = attackBonus;
    }

    public override void Use(Player player)
    {
        
        Console.WriteLine($"{player.Name} inspects {Name}.");
        Console.WriteLine($"{Description}");
        Console.WriteLine($"It would add +{AttackBonus} attack when equipped.");
    }
}
