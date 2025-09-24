using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        Console.Write("What's your first name?");
        string firstname = Console.ReadLine();
        Console.Write("What is your last name?");
        string lastname = Console.ReadLine();
        Console.WriteLine($"Your name is {lastname}, {firstname} {lastname}");

    }
}