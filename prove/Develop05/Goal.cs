using System;

public abstract class Goal
{
    protected string _title;
    protected string _description;
    protected int _points;

    public Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
        _points = points;
    }

    // Returns how many points were earned when recording the event
    public abstract int RecordEvent();

    // Whether the goal is complete
    public abstract bool IsComplete();

    // Used when saving to a file
    // Format example: "SimpleGoal:Title,Description,50,True"
    public abstract string GetStringRepresentation();

    // Displays goal information to screen
    public abstract void Display();

    // Required so GoalManager can rebuild goals from save data
    public static Goal FromString(string data)
    {
        // Split type vs rest
        string[] parts = data.Split(':');
        string goalType = parts[0];
        string[] values = parts[1].Split(',');
        string title = values[0];
        string description = values[1];
        int points = int.Parse(values[2]);

        if (goalType == "SimpleGoal")
        {
            bool completed = bool.Parse(values[3]);
            return new Simple_Goal(title, description, points, completed);
        }

        else if (goalType == "EternalGoal")
        {
            return new Eternal_Goal(title, description, points);
        }
        else if (goalType == "ChecklistGoal")
        {
            int current = int.Parse(values[3]);
            int target = int.Parse(values[4]);
            int bonus = int.Parse(values[5]);

            return new Checklist_Goal(title, description, points, target, bonus, current);
        }

        throw new Exception("Unknown goal type: " + goalType);
    }
}
