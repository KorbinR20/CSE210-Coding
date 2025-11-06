using System;
using System.Collections.Generic;
using System.Threading;

public class Reflecting : Activity
{
    private List<string> _prompts = new List<string>
    {
      "Think of a time when you stood up for someone else.",
      "Think of a time when you did something really challenging.",
      "Think of a time when you helped someone in need.",
      "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    private Timer _timer = new Timer();
    public Reflecting(): base("Reflecting",
                "This activity will help you reflect on times in your life when you have shown strength and resilience. " +
               "It will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public void ReflectingStart()
    {
        DisplayStartingMessage();

        Console.Clear();
        Console.WriteLine($"Get ready to reflect...");
        Thread.Sleep(2000);

        string prompt = GetRandomPrompt();
        Console.WriteLine($"\n--- {prompt} ---");
        Console.WriteLine("\nWhen you have something in mind, press ENTER to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.WriteLine("You may begin in:");
        Countdown(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.Write($"> {question} ");
            _timer.SpinnerAnimation(5);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        Random random = new Random();
        return _questions[random.Next(_questions.Count)];
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
