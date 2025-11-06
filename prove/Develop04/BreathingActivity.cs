using System;
using System.Threading;

public class Breathing : Activity
{
    private Timer _timer = new Timer();

    public Breathing()
        : base("Breathing", 
               "This activity will help you relax by guiding your breathing. Focus on slow, deep breaths.")
    {
    }

    public void BreathingStart()
    {
        DisplayStartingMessage();

        Console.Clear();
        Console.WriteLine("Get ready to begin...");
        Thread.Sleep(2000);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("\nBreathe in...");
            _timer.SpinnerAnimation(5); // inhale for 5 seconds

            Console.WriteLine("Now breathe out...");
            _timer.SpinnerAnimation(5); // exhale for 5 seconds
        }

        DisplayEndingMessage();
    }
}
