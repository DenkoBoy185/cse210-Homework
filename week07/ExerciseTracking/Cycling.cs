using System;

// Derived class representing a cycling (stationary or road) activity.
// Stores speed in miles per hour as its unique attribute.
class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int lengthInMinutes, double speed)
        : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    public override string GetActivityName() => "Cycling";

    // Distance = speed * (minutes / 60).
    public override double GetDistance() => _speed * (LengthInMinutes / 60.0);

    // Speed is stored directly in mph.
    public override double GetSpeed() => _speed;

    // Pace = minutes per mile.
    public override double GetPace() => 60 / _speed;
}
