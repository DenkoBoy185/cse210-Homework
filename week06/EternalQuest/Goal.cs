using System;

// Base class for all goal types.
// Contains shared attributes (name, description, points) and declares
// abstract methods that each derived class must implement (polymorphism).
abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string Name => _name;
    public int Points => _points;

    // Returns true when the goal has been fully completed.
    // Eternal goals override this to always return false.
    public virtual bool IsComplete => false;

    // Records a single event and returns the points awarded (can be negative).
    public abstract int RecordEvent();

    // Returns a single-line display string showing goal status.
    public abstract string GetDetailsString();

    // Returns a serializable string representation for file saving.
    public abstract string GetStringRepresentation();
}
