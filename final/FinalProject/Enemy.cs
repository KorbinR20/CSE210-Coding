using System;

public class Enemy : Character
{
    public string EnemyType { get; private set; }
    public int ExperienceReward { get; private set; }
    public int GoldReward { get; private set; }

    public Enemy(string name,
                 string enemyType,
                 int maxHealth,
                 int attackPower,
                 int defense,
                 int expReward,
                 int goldReward)
        : base(name, maxHealth, attackPower, defense)
    {
        EnemyType = enemyType;
        ExperienceReward = expReward;
        GoldReward = goldReward;
    }

    public override int Attack()
    {
        Random rand = new Random();
        int variance = rand.Next(-2, 3);
        int damage = AttackPower + variance;
        if (damage < 0) damage = 0;
        return damage;
    }

    public override void DisplayStats()
    {
        Console.WriteLine($"\nEnemy: {Name} the {EnemyType}");
        Console.WriteLine($"HP: {Health}/{MaxHealth}");
        Console.WriteLine($"Attack: {AttackPower}  Defense: {Defense}");
        Console.WriteLine($"Rewards: {ExperienceReward} XP, {GoldReward} gold");
    }
}