using System;

class Scripture
{
    private string _book;
    private int _chapter;
    private int _verse1;
    private int _verse2;

    public Scripture(string book, int chapter, int Verse)
    {
        _book = book;
        _chapter = chapter;
        _verse1 = Verse;
        _verse2 = Verse;

    }

 public Scripture(string book, int chapter, int Verse1, int Verse2)
    {
        _book = book;
        _chapter = chapter;
        _verse1 = Verse1;
        _verse2 = Verse2;

    }
    public string GetDisplayText()
    {
        if (_verse1 == _verse2)
            return $"{_book} {_chapter}:{_verse1}";
        else
            return $"{_book} {_chapter}:{_verse1}-{_verse2}";
    }
    // Proverbs 3:5-6
}