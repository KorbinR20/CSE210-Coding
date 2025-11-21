public class Simple_Goal : Goal
{
    private bool _isComplete;

    public Simple_Goal(string title, string desc, int points)
        : base(title, desc, points)
    {
        _isComplete = false;
    }

    public Simple_Goal(string title, string desc, int points, bool completed)
        : base(title, desc, points)
    {
        _isComplete = completed;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_title},{_description},{_points},{_isComplete}";
    }

    public override void Display()
{
    string check = _isComplete ? "[X]" : "[ ]";
    Console.WriteLine($"{check} {_title} ({_description})");
}

}
