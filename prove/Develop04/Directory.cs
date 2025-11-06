class Directory
{
    public string _options;
    public void Display()
    {
            _options = @"
    ===== Mediation App =====
    1. Breathing Activity
    2. Reflecting Activity
    3. Listing Activity
    4. Quit
    =========================
    Choose an option: ";
        Console.Write(_options);
    }
}