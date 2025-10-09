class Entry
{
    public string _prompt;
    public string _entryDate;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine();
        Console.WriteLine($"{_entryDate} ");
        Console.WriteLine($"{_prompt}");
        Console.WriteLine($"{_entryText}");
    }
}