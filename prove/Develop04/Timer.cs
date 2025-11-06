using System;
using System.Threading;

public class Timer
{
    private string _spinner = "|/-\\";

    public void SpinnerAnimation(int seconds)
    {
        int spinnerIndex = 0;
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(_spinner[spinnerIndex]);   // print current symbol
            Thread.Sleep(250);                       // wait 0.25 seconds
            Console.Write("\b \b");                  // erase the spinner
            spinnerIndex = (spinnerIndex + 1) % _spinner.Length; // move to next symbol
        }
    }
}