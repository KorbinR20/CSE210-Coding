using System;

public class Checklist_Goal : Goal
{
    private int _currentCount;
    private int _targetCount;
    private int _bonus;

    public Checklist_Goal(string title, string description, int points,
                          int targetCount, int bonus)
        : base(title, description, points)
    {
        _currentCount = 0;
        _targetCount = targetCount;
        _bonus = bonus;
    }

    // Overload for loading from file
    public Checklist_Goal(string title, string description, int points,
                          int targetCount, int bonus, int currentCount)
        : base(title, description, points)
    {
        _currentCount = currentCount;
        _targetCount = targetCount;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            if (_currentCount == _targetCount)
            {
                Console.WriteLine("🎉 Goal Completed! Bonus awarded!");
                return _points + _bonus;
            }
            return _points;
        }
        return 0; // Already completed
    }

    public override bool IsComplete()
    {
        return _currentCount >= _targetCount;
    }

    public override string GetStringRepresentation()
    {
        // Format: ChecklistGoal:Title,Description,Points,Current,Target,Bonus
        return $"ChecklistGoal:{_title},{_description},{_points},{_currentCount},{_targetCount},{_bonus}";
    }

    public override void Display()
    {
        string check = IsComplete() ? "[X]" : "[ ]";
        Console.WriteLine($"{check} {_title} ({_description}) -- Progress: {_currentCount}/{_targetCount}");
    }
}
