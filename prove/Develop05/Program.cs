GoalManager manager = new GoalManager();
Directory menu = new Directory();
bool running = true;

while (running)
{
    Console.Clear(); // Clears the screen before showing menu

    Console.WriteLine($"You have {manager.GetScore()} points.\n");

    menu.Display();
    Console.Write("Select a choice: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            manager.AddGoal();
            break;

        case "2":
            manager.ListGoals();
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
            break;

        case "3":
            Console.Write("Enter filename to save: ");
            string saveFile = Console.ReadLine();
            manager.SaveGoals(saveFile);
            break;

        case "4":
            Console.Write("Enter filename to load: ");
            string loadFile = Console.ReadLine();
            manager.LoadGoals(loadFile);
            break;

        case "5":
            manager.RecordEvent();
            break;

        case "6":
            running = false;
            break;

        default:
            Console.WriteLine("Invalid option. Press Enter to continue.");
            Console.ReadLine();
            break;
    }
}