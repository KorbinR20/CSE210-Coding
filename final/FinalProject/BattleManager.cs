using System;

public class BattleManager
{
    private Player _player;
    private Enemy _enemy;
    private Inventory _inventory;

    public BattleManager(Player player, Enemy enemy, Inventory inventory)
    {
        _player = player;
        _enemy = enemy;
        _inventory = inventory;
    }

    // Core Battle Loop
    public void StartBattle()
    {
        Console.WriteLine($"\nA wild {_enemy.Name} appears!");
        _enemy.DisplayStats();

        while (_player.IsAlive && _enemy.IsAlive)
        {
            Console.WriteLine("\n=== Your Turn ===");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Use Item");
            Console.WriteLine("3. View Stats");
            Console.Write("Choose an action: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    PlayerAttack();
                    break;

                case "2":
                    _inventory.UseItem(_player);
                    break;

                case "3":
                    _player.DisplayStats();
                    continue; // skip enemy turn
                default:
                    Console.WriteLine("Invalid option.");
                    continue;
            }

            // Check if the enemy died before it attacks
            if (!_enemy.IsAlive)
                break;

            EnemyAttack();
        }

        EndBattle();
    }

    private void PlayerAttack()
    {
        int damage = _player.Attack();
        Console.WriteLine($"{_player.Name} attacks {_enemy.Name} for {damage} damage!");
        _enemy.TakeDamage(damage);
    }

    private void EnemyAttack()
    {
        Console.WriteLine($"\n=== Enemy Turn ===");
        int damage = _enemy.Attack();
        Console.WriteLine($"{_enemy.Name} attacks {_player.Name} for {damage} damage!");
        _player.TakeDamage(damage);
    }

    private void EndBattle()
    {
        Console.WriteLine("\n=== Battle Over ===");

        if (!_player.IsAlive)
        {
            Console.WriteLine($"{_player.Name} has been defeated...");
            return;
        }

        Console.WriteLine($"{_player.Name} defeated {_enemy.Name}!");

        // Reward player
        _player.GainExperience(_enemy.ExperienceReward);
        _player.AddGold(_enemy.GoldReward);

        Console.WriteLine($"You earned {_enemy.ExperienceReward} XP and {_enemy.GoldReward} gold!");
    }
}
