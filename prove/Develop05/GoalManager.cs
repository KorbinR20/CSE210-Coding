using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal()
    {
        Console.WriteLine("Select the type of goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("What kind of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.WriteLine("What is a short description of your goal? ");
        string desc = Console.ReadLine();

        Console.WriteLine("How many points do you want this goal to be worth? ");
        int points = int.Parse(Console.ReadLine());

        if (choice == "1")
        {
            _goals.Add(new Simple_Goal(name, desc, points));
        }
        else if (choice == "2")
        {
            _goals.Add(new Eternal_Goal(name, desc, points));
        }
        else if (choice == "3")
        {
            Console.Write("How many times required? ");
            int requiredCount = int.Parse(Console.ReadLine());

            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new Checklist_Goal(name, desc, points, requiredCount, bonus));
        }
    }

     public void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");

        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.Write($"{index}. ");
            goal.Display();
            index++;
        }
        Console.WriteLine($"\nTotal Score: {_score}\n");
    }

    public void RecordEvent()
    {
        ListGoals();
        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < _goals.Count)
        {
            int gained = _goals[choice].RecordEvent();
            _score += gained;
            Console.WriteLine($"\nYou gained {gained} points!");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        _goals.Clear();

        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            Goal loaded = Goal.FromString(lines[i]);
            _goals.Add(loaded);
        }
    }
    public int GetScore()
    {
        return _score;
    }
}