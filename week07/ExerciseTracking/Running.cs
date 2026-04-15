using System;

// Derived class representing a running activity.
// Stores the distance in miles as its unique attribute.
class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int lengthInMinutes, double distance)
        : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    public override string GetActivityName() => "Running";

    // Distance is stored directly in miles.
    public override double GetDistance() => _distance;

    // Speed = distance / (minutes / 60) = miles per hour.
    public override double GetSpeed() => (_distance / LengthInMinutes) * 60;

    // Pace = minutes per mile.
    public override double GetPace() => LengthInMinutes / _distance;
}
