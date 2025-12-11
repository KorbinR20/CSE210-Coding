using System;

public abstract class Item
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int GoldValue { get; protected set; }

    public Item(string name, string description, int goldValue)
    {
        Name = name;
        Description = description;
        GoldValue = goldValue;
    }

    // Polymorphic method — MUST exist or Inventory cannot call item.Use(player)
    public abstract void Use(Player player);
}
