class Directory
{
    public string _options;
    public void Display()
    {
        _options = @"
        Please Select a number on what you want to do:
        1. Add New Entry
        2. Show Previous Entries
        3. Save Entries
        4. Load Entries
        5. Quit";
        Console.WriteLine(_options);
    }
}