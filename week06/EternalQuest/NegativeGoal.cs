// EXCEEDS REQUIREMENTS: NegativeGoal
// Represents a bad habit the user wants to stop. Recording it DEDUCTS points
// as a deterrent, encouraging the user to avoid the behavior.
class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    // Negative goals are never "complete" — bad habits can always recur.
    public override bool IsComplete => false;

    // Returns a negative value to deduct points from the score.
    public override int RecordEvent()
    {
        return -_points;
    }

    public override string GetDetailsString()
    {
        return $"[-] {_name} ({_description}) [DEDUCTS {_points} pts]";
    }

    // Format: NegativeGoal:name,description,points
    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_name},{_description},{_points}";
    }
}
