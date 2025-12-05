using System;
using System.Collections.Generic;

public class Player : Character
{
    public int Level { get; private set; }
    public int Experience { get; private set; }
    public int Gold { get; private set; }

    private List<string> _inventory = new List<string>();

    public Player(string name, int maxHealth, int attackPower, int defense)
        : base(name, maxHealth, attackPower, defense)
    {
        Level = 1;
        Experience = 0;
        Gold = 0;
    }

    public void GainExperience(int amount)
    {
        Experience += amount;

        while (Experience >= 100)
        {
            Experience -= 100;
            Level++;
            AttackPower += 2;
            MaxHealth += 5;
            Health = MaxHealth;

            Console.WriteLine($"Amazing! {Name} leveled up to level {Level}!");
        }
    }
    public void AddGold(int amount)
    {
        Gold += amount;
    }

    public bool SpendGold(int amount)
    {
        if (Gold >= amount)
        {
            Gold -= amount;
            return true;
        }
        return false;
    }

    public void AddItem(string itemName)
    {
        _inventory.Add(itemName);
    }

    public void ShowInventory()
    {
        Console.WriteLine($"\n{DontMakeNull(Name)}'s Inventory:");
        if (_inventory.Count == 0)
        {
            Console.WriteLine("  (empty)");
            return;
        }

        int index = 1;
        foreach (string item in _inventory)
        {
            Console.WriteLine($"  {index}. {item}");
            index++;
        }
    }

    // Override to include level in attack damage
    public override int Attack()
    {
        // Example: base attack + level bonus
        int damage = AttackPower + (Level - 1);
        return damage;
    }

    // Override to show more info about the player
    public override void DisplayStats()
    {
        Console.WriteLine($"\nPlayer: {Name}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine($"HP: {Health}/{MaxHealth}");
        Console.WriteLine($"Attack: {AttackPower}");
        Console.WriteLine($"Gold: {Gold}");
    }

    // Small helper to avoid null name issues in case you construct weirdly
    private string DontMakeNull(string value) => value ?? "Player";
}