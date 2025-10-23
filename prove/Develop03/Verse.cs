using System;
using System.ComponentModel.DataAnnotations;

class Verse
{
    private Scripture _newVerse;
    private List<Word> _words;

    public Verse()
    {
        _newVerse = new Scripture("Proverbs", 3, 5, 6);
        _words = new List<Word>();
        
        // Trust in the Lord with all thine heart; and lean not unto thine own understanding.
        // In all thy ways achknowledge him, and he shall direct thy paths.
        string message = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways achknowledge him, and he shall direct thy paths.";
        string[] parts = message.Split(" ");
        foreach (string part in parts)
        {
            Word w = new Word(part);
            _words.Add(w);
        }
    }
    public string GetDisplay()
    {
        string show = _newVerse.GetDisplayText();
        foreach (Word order in _words)
        {
            show += $" {order.GetDisplayedWord()}";
        }
        return show;
    }
    public void HideWord()
    {
        Random hide = new Random();
        List<Word> visibleWords = _words.Where(w => w.IsRevealed()).ToList();

    if (visibleWords.Count == 0)
        {
            return;
        }
    int wordsToHide = hide.Next(1, 6);
    wordsToHide = Math.Min(wordsToHide, visibleWords.Count);
    for (int i = 0; i < wordsToHide; i++)
        {
        int randomIndex = hide.Next(visibleWords.Count);
        visibleWords[randomIndex].Hide();
        visibleWords.RemoveAt(randomIndex);
        }
    }
    public bool AllHidden()
    {
        foreach (Word w in _words)
        {
            if (w.IsRevealed())
            {
                return false;
            }
        }
        return true;
    }   
}
