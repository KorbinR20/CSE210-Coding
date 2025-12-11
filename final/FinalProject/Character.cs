using System;

public abstract class Character
{
    public string Name { get; protected set; }
    public int MaxHealth { get; protected set; }
    public int Health { get; protected set; }
    public int AttackPower { get; protected set; }
    public int Defense { get; protected set; }

    protected Character(string name, int maxHealth, int attackPower, int defense)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
        AttackPower = attackPower;
        Defense = defense;
    }

    // ----- METHODS YOU OVERRIDE IN Player -----

    // Base version returns plain attack power
    public virtual int Attack()
    {
        return AttackPower;
    }

    public virtual void DisplayStats()
    {
        Console.WriteLine($"{Name} - HP: {Health}/{MaxHealth}, ATK: {AttackPower}, DEF: {Defense}");
    }

    // Other useful stuff
    public virtual void TakeDamage(int amount)
    {
        int damage = Math.Max(1, amount - Defense);
        Health -= damage;
        if (Health < 0) Health = 0;

        Console.WriteLine($"{Name} takes {damage} damage. HP: {Health}/{MaxHealth}");
    }

    public bool IsAlive => Health > 0;
        public void Heal(int amount)
    {
        Health += amount;
        if (Health > MaxHealth)
            Health = MaxHealth;
    }
}