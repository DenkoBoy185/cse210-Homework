using System;

// Base class for all exercise activity types.
// Stores the date and duration (length in minutes) common to all activities.
// Declares abstract methods for distance, speed, and pace that each subclass must implement.
abstract class Activity
{
    private DateTime _date;
    private int _lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    protected int LengthInMinutes => _lengthInMinutes;

    // Returns the display name of the activity type (e.g., "Running").
    public abstract string GetActivityName();

    // Returns distance covered in miles (or km equivalent for swimming).
    public abstract double GetDistance();

    // Returns speed in miles per hour.
    public abstract double GetSpeed();

    // Returns pace in minutes per mile.
    public abstract double GetPace();

    // Builds and returns a formatted summary string using the virtual methods above.
    // This single method in the base class handles all activity types via polymorphism.
    public string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetActivityName()} ({_lengthInMinutes} min)" +
               $" - Distance {GetDistance():F1} miles," +
               $" Speed: {GetSpeed():F1} mph," +
               $" Pace: {GetPace():F2} min per mile";
    }
}
