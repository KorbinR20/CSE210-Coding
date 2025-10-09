using System;
using System.IO.Enumeration;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        myJournal._entries = new List<Entry>();

        Directory displayDirectory = new Directory();
        while (true)
        {
            displayDirectory.Display();

            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                Prompts myPrompts = new Prompts();
                string prompt = myPrompts.GetPrompt();
                Console.WriteLine($"{prompt}");

                Entry myEntry = new Entry();
                myEntry._prompt = prompt;

                DateTime theCurrentTime = DateTime.Now;
                string dateText = theCurrentTime.ToShortDateString();

                myEntry._entryDate = dateText;
                Console.Write($"");
                string message = Console.ReadLine();
                myEntry._entryText = message;
                // myEntry.Display();

                myJournal._entries.Add(myEntry);
                // myJournal.Display();
            }
            else if (userInput == "2")
            {
                myJournal.Display();
            }
            else if (userInput == "3")
            {
                Console.WriteLine("What is the file name? ");
                myJournal._fileName = Console.ReadLine();
                myJournal.Save();
            }
            else if (userInput == "4")
            {
                Console.WriteLine("What is the file name? ");
                myJournal._fileName = Console.ReadLine();
                myJournal._entries = new List<Entry>();
                myJournal.Load();
            }
            else if (userInput == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid Input! Try again");
            }
        }
    }
}