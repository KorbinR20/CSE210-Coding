using System;
using System.Collections.Generic;

public class Inventory
{
    private List<Item> _items = new List<Item>();

    // Add an item to the inventory
    public void AddItem(Item item)
    {
        if (item == null) return;

        _items.Add(item);
        Console.WriteLine($"{item.Name} was added to your inventory.");
    }

    // Remove an item (used internally after using consumables, etc.)
    public void RemoveItem(Item item)
    {
        _items.Remove(item);
    }

    // Returns the list of items
    public List<Item> GetItems()
    {
        return _items;
    }

    // Show everything the player is carrying
    public void ListItems()
    {
        if (_items.Count == 0)
        {
            Console.WriteLine("\nYour inventory is empty.");
            return;
        }

        Console.WriteLine("\n=== Inventory ===");
        for (int i = 0; i < _items.Count; i++)
        {
            Item item = _items[i];
            Console.WriteLine($"{i + 1}. {item.Name} - {item.Description} (Value: {item.GoldValue}g)");
        }
    }

    public int CountItems()
    {
        return _items.Count;
    }

    // Let the player choose and use an item
    public void UseItem(Player player)
    {
        if (_items.Count == 0)
        {
            Console.WriteLine("\nYou have no items to use.");
            return;
        }

        ListItems();
        Console.Write("\nChoose an item number to use (or 0 to cancel): ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int choice))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        if (choice == 0) return;

        int index = choice - 1;
        if (index < 0 || index >= _items.Count)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        Item item = _items[index];

        item.Use(player);

        // Example: remove consumables after use
        if (item is HealthPotion)
        {
            _items.RemoveAt(index);
        }
    }

    // Optional helpers
    public bool HasItems => _items.Count > 0;
}