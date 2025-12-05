using System;

public class Goblin : Enemy
{
    public Goblin()
    : base("Goblin", "Goblin", 30, 6, 2, 20, 10)
    {
    }

    public override int Attack()
    {
        int damage = AttackPower;
        Random rnd = new Random();
        if (rnd.Next(1, 101) <= 20)
        {
            Console.WriteLine("The Goblin performs a sneak attack!");
            damage += 4;
        }
        return damage;
    }

    public override void DisplayStats()
    {
        Console.WriteLine("\n=== Goblin ===");
        Console.WriteLine($"HP: {Health}/{MaxHealth}");
        Console.WriteLine($"Attack: {AttackPower}");
        Console.WriteLine($"Defense: {Defense}");
    }
}