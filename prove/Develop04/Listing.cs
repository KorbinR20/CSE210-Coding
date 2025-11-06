using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

public class Listing : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private List<string> _responses = new List<string>();
    public Listing()
       : base("Listing", 
               "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public void ListingStart()
    {
        DisplayStartingMessage();

        Console.Clear();
        Console.WriteLine($"Get ready to reflect...");
        Thread.Sleep(2000);

        string prompt = GetRandomPrompt();
        Console.WriteLine($"\n--- {prompt} ---");
        Console.WriteLine($"\nYou may begin in:");
        Countdown(5);

        Console.WriteLine("Start listing items! Press Enter after each one.\n");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                _responses.Add(response);
            }
        }
        Console.WriteLine($"\nYou listed {_responses.Count} items!");
        DisplayEndingMessage();
    }
    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
    private void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}