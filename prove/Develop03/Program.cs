using System;

class Program
{
    static void Main(string[] args)
    {
      
        Verse newVerse = new Verse();
        while (true)
        {
            string displayString = newVerse.GetDisplay();
            Console.Clear();
            Console.WriteLine($"{displayString}");
            Console.WriteLine($"Press Enter to hide more words. If you would like to stop, type 'quit' ");

            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "quit")
            {
                break;
            }
            newVerse.HideWord();

            if (newVerse.AllHidden())
            {
                Console.Clear();
                Console.WriteLine(newVerse.GetDisplay());
                break;
            }

        }
    }
}