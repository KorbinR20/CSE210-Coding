using System;
using System.Collections.Generic;

public class Player : Character
{
    public int Level { get; private set; }
    public int Experience { get; private set; }
    public int Gold { get; private set; }

    // The REAL inventory object
    public Inventory Inventory { get; private set; } = new Inventory();

    public Player(string name, int maxHealth, int attackPower, int defense)
        : base(name, maxHealth, attackPower, defense)
    {
        Level = 1;
        Experience = 0;
        Gold = 0;
    }

    // ---------------------------
    // EXPERIENCE + LEVELING
    // ---------------------------
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

    // ---------------------------
    // GOLD MANAGEMENT
    // ---------------------------
    public void AddGold(int amount) => Gold += amount;

    public bool SpendGold(int amount)
    {
        if (Gold >= amount)
        {
            Gold -= amount;
            return true;
        }
        return false;
    }

    // ---------------------------
    // ITEM HANDLING
    // ---------------------------
    public void AddItem(Item item)
    {
        Inventory.AddItem(item);
    }

    public void UseItem()
    {
        Inventory.UseItem(this);
    }

    public void ShowInventory()
    {
        Inventory.ListItems();
    }

    // ---------------------------
    // COMBAT
    // ---------------------------
    public override int Attack()
    {
        int damage = AttackPower + (Level - 1);
        return damage;
    }

    public override void DisplayStats()
    {
        Console.WriteLine($"\nPlayer: {Name}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine($"HP: {Health}/{MaxHealth}");
        Console.WriteLine($"Attack: {AttackPower}");
        Console.WriteLine($"Gold: {Gold}");
    }
}
