using System;

class Word
{
    private string _word;
    private bool _revealed;


    public Word(string w)
    {
        _word = w;
        _revealed = true;
    }
    public void Display()
    {
        if (_revealed)
        {
            Console.Write(" " + _word);
        }
        else
        {
            int size = _word.Length;
            for (int i = 0; i < size; i++)
            {
                Console.Write("_");
            }
        }
    }
    public string GetDisplayedWord()
    {
        if (_revealed)
        {
            return _word;
        }
        else
        {
            string blanks = "";
            int size = _word.Length;
            for (int i = 0; i < size; i++)
            {
                blanks += "_";
            } 
            return blanks;           
        }
    }
    public void Hide()
    {
        _revealed = false;
    }
    public bool IsRevealed()
    {
        return _revealed;
    }
}