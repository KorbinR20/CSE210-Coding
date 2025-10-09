class Prompts
{
    public string _question1 = "What did you enjoy the most about your day? ";
    public string _question2 = "Who did you see or meet today? ";
    public string _question3 = "What enjoyable thing did you do today? ";
    public string _question4 = "What was the hardest thing you accomplished today? ";
    public string _question5 = "How did you get through the day? ";

    public string GetPrompt()
    {
        Random randomQuestion = new Random();
        int magicNumber = randomQuestion.Next(1, 6);
        string question = "What are you most grateful for today?";
        if (magicNumber == 1)
        {
            question = _question1;
        }
        else if (magicNumber == 2)
        {
            question = _question2;
        }
        else if (magicNumber == 3)
        {
            question = _question3;
        }
        else if (magicNumber == 4)
        {
            question = _question4;
        }
        else if (magicNumber == 5)
        {
            question = _question5;
        }
        return question;
    }
    public void Display()
    {
        Console.WriteLine($"{_question1}");
        Console.WriteLine($"{_question2}");
        Console.WriteLine($"{_question3}");
        Console.WriteLine($"{_question4}");
        Console.WriteLine($"{_question5}");
    }
}