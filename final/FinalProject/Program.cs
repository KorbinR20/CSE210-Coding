using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the RPG Simulator!");
        Console.Write("Enter your character's name: ");
        string playerName = Console.ReadLine();

        Player player = new Player(playerName, maxHealth: 50, attackPower: 8, defense: 3);
        Inventory inventory = new Inventory();
        BattleManager battleManager = null;

        while (true)
        {
            Console.WriteLine("\n=== MAIN MENU ===");
            Console.WriteLine("1. View Player Stats");
            Console.WriteLine("2. View Inventory");
            Console.WriteLine("3. Start Battle (Goblin)");
            Console.WriteLine("4. Fight the Dragon (Boss)");
            Console.WriteLine("5. Visit Shop");
            Console.WriteLine("6. Quit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    player.DisplayStats();
                    break;

                case "2":
                    inventory.ListItems();
                    break;

                case "3":
                    Enemy goblin = new Goblin();
                    battleManager = new BattleManager(player, goblin, inventory);
                    battleManager.StartBattle();
                    break;

                case "4":  // ⭐ DRAGON BATTLE HERE
                    Enemy dragon = new Dragon();
                    battleManager = new BattleManager(player, dragon, inventory);
                    battleManager.StartBattle();
                    break;

                case "5":
                    RunShop(player, inventory);
                    break;

                case "6":
                    Console.WriteLine("Thanks for playing!");
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    // -----------------------------
    // SHOP MENU
    // -----------------------------
    static void RunShop(Player player, Inventory inventory)
    {
        while (true)
        {
            Console.WriteLine("\n=== SHOP ===");
            Console.WriteLine($"Gold: {player.Gold}");
            Console.WriteLine("1. Buy Health Potion (10g)");
            Console.WriteLine("2. Buy Iron Sword (25g)");
            Console.WriteLine("3. Leave Shop");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    if (player.SpendGold(10))
                    {
                        inventory.AddItem(new HealthPotion(
                            "Health Potion",
                            "Restores 25 HP",
                            10,
                            25));

                        Console.WriteLine("You bought a Health Potion!");
                    }
                    else
                    {
                        Console.WriteLine("Not enough gold!");
                    }
                    break;

                case "2":
                    if (player.SpendGold(25))
                    {
                        inventory.AddItem(new Weapon(
                            "Iron Sword",
                            "A simple iron blade",
                            25,
                            3));

                        Console.WriteLine("You bought an Iron Sword!");
                    }
                    else
                    {
                        Console.WriteLine("Not enough gold!");
                    }
                    break;

                case "3":
                    Console.WriteLine("Leaving shop...");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
