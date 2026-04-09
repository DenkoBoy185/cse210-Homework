// A one-time goal. Once recorded, it is marked complete and cannot be recorded again.
class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override bool IsComplete => _isComplete;

    // Awards points and marks the goal complete. Returns 0 if already done.
    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }
        _isComplete = true;
        return _points;
    }

    public override string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description})";
    }

    // Format: SimpleGoal:name,description,points,isComplete
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_name},{_description},{_points},{_isComplete}";
    }
}
