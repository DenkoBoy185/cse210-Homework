using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create one instance of each activity type.
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 3.0));
        activities.Add(new Cycling(new DateTime(2022, 11, 3), 50, 9.7));
        activities.Add(new Swimming(new DateTime(2022, 11, 3), 40, 20));

        // Call GetSummary on each — polymorphism via the base class method.
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}