using System;

// Derived class representing a swimming activity.
// Stores the number of laps as its unique attribute.
// 1 lap = 50 meters; conversion: 1000 meters = 0.62137 miles.
class Swimming : Activity
{
    private int _numberOfLaps;

    private const double MetersPerLap = 50.0;
    private const double MilesPerMeter = 0.000621371;

    public Swimming(DateTime date, int lengthInMinutes, int numberOfLaps)
        : base(date, lengthInMinutes)
    {
        _numberOfLaps = numberOfLaps;
    }

    public override string GetActivityName() => "Swimming";

    // Converts laps → meters → miles.
    public override double GetDistance() => _numberOfLaps * MetersPerLap * MilesPerMeter;

    // Speed = distance / (minutes / 60).
    public override double GetSpeed() => (GetDistance() / LengthInMinutes) * 60;

    // Pace = minutes per mile.
    public override double GetPace() => LengthInMinutes / GetDistance();
}
