// A goal that must be accomplished a fixed number of times to be completed.
// Awards regular points each time, plus a bonus on the final completion.
class ChecklistGoal : Goal
{
    private int _currentCount;
    private int _requiredCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int requiredCount, int bonus)
        : base(name, description, points)
    {
        _currentCount = 0;
        _requiredCount = requiredCount;
        _bonus = bonus;
    }

    public override bool IsComplete => _currentCount >= _requiredCount;

    // Awards base points each time; also awards bonus on the final completion.
    public override int RecordEvent()
    {
        if (IsComplete)
        {
            return 0;
        }
        _currentCount++;
        int earned = _points;
        if (IsComplete)
        {
            earned += _bonus;
        }
        return earned;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description}) -- currently completed {_currentCount}/{_requiredCount} times";
    }

    // Format: ChecklistGoal:name,description,points,bonus,currentCount,requiredCount
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_name},{_description},{_points},{_bonus},{_currentCount},{_requiredCount}";
    }
}
