using System;

public class Eternal_Goal : Goal
{
    public Eternal_Goal(string title, string description, int points)
        : base(title, description, points)
    {
    }

    // Eternal goals never complete — always award points
    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete()
    {
        return false; 
    }

    public override string GetStringRepresentation()
    {
        // Format Example: EternalGoal:Title,Description,Points
        return $"EternalGoal:{_title},{_description},{_points}";
    }

    public override void Display()
    {
        Console.WriteLine($"[] {_title} ({_description}) -- {_points} points each time");
    }
}
