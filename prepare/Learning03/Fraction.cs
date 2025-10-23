using System;

public class Fraction
{
    private int _numerator;
    private int _demoninator;

    public Fraction()
    {
        _numerator = 1;
        _demoninator = 3;
    }

    public Fraction(int wholeNumber)
    {
        _numerator = wholeNumber;
        _demoninator = 1;
    }

    public Fraction(int top, int bottom)
    {
        _numerator = top;
        _demoninator = bottom;
    }
    public string GetFractionString()
    {
        string text = $"{_numerator}/{_demoninator}";
        return text;
    }
    public double GetDecimalValue()
    {
        return (double)_numerator / (double)_demoninator;
    }
}