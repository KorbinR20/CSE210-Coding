using System;

public class Dragon : Enemy
{
    // You can tweak these numbers however you like
    private const int DRAGON_MAX_HEALTH  = 120;
    private const int DRAGON_ATTACK      = 18;
    private const int DRAGON_DEFENSE     = 8;
    private const int DRAGON_XP_REWARD   = 120;
    private const int DRAGON_GOLD_REWARD = 200;

    public Dragon()
        : base(
            name: "Ancient Dragon",
            enemyType: "Dragon",
            maxHealth: DRAGON_MAX_HEALTH,
            attackPower: DRAGON_ATTACK,
            defense: DRAGON_DEFENSE,
            expReward: DRAGON_XP_REWARD,
            goldReward: DRAGON_GOLD_REWARD)
    {
    }

    // Stronger, more swingy attack with a chance for fire breath bonus
    public override int Attack()
    {
        Random rand = new Random();

        // base damage with a bit of variance
        int damage = AttackPower + rand.Next(-3, 4);
        if (damage < 0) damage = 0;

        // 30% chance to breathe fire for extra damage
        if (rand.Next(1, 101) <= 30)
        {
            Console.WriteLine("🔥 The Dragon breathes FIRE!");
            damage += 10;
        }

        return damage;
    }

    public override void DisplayStats()
    {
        Console.WriteLine("\n=== BOSS: DRAGON ===");
        Console.WriteLine($"Name: {Name} the {EnemyType}");
        Console.WriteLine($"HP: {Health}/{MaxHealth}");
        Console.WriteLine($"Attack: {AttackPower}  Defense: {Defense}");
        Console.WriteLine($"Rewards: {ExperienceReward} XP, {GoldReward} gold");
    }
}
