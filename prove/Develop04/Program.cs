using System;

class Program
{
    static void Main(string[] args)
    {
        Directory displayDirectory = new Directory();
        bool running = true;
        while (running)
        {
            displayDirectory.Display();
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                Console.Clear();
                Breathing breathing = new Breathing();
                breathing.BreathingStart();
            }
            else if (userInput == "2")
            {
                Console.Clear();
                Reflecting reflecting = new Reflecting();
                reflecting.ReflectingStart();
                
            }
            else if (userInput == "3")
            {
                Console.Clear();
                Listing listing = new Listing();
                listing.ListingStart();
            }
            else if (userInput == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("\nInvalid input! Try again.");

                Console.ReadKey( );
            }
        }
    }
}