class Directory
{
    public string _options;
    public void Display()
    {
        _options = @"
        Menu Options:
            1. Create New Goal
            2. List Goals
            3. Save Goals
            4. Load Goals
            5. Record Event
            6. Quit";
        Console.WriteLine(_options);
    }
}