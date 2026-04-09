// An ongoing goal that is never truly complete.
// Each time it is recorded the user receives points,
// but the goal stays active indefinitely.
class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    // Eternal goals are never complete — always returns false.
    public override bool IsComplete => false;

    // Always awards full points; cannot be "finished".
    public override int RecordEvent()
    {
        return _points;
    }

    public override string GetDetailsString()
    {
        return $"[∞] {_name} ({_description})";
    }

    // Format: EternalGoal:name,description,points
    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_name},{_description},{_points}";
    }
}
