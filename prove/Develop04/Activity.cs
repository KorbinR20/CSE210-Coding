using System;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity!");
        Console.WriteLine(_description);
        Console.Write("\nEnter the duration of the activity (in seconds): ");
        _duration = int.Parse(Console.ReadLine());
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"\nGreat job! You completed {_duration} seconds of {_name}.");
    }

    public void Start()
    {
        
    }
}
