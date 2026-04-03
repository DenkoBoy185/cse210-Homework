using System;
using System.Collections.Generic;

// CREATIVITY / EXCEEDS REQUIREMENTS:
// 1. Activity Log: The program tracks how many times each activity has been performed
//    during the session and displays these counts in the menu.
// 2. No-Repeat Prompts/Questions: Each activity uses a shuffle-pool approach so that
//    prompts and questions are never repeated until all have been used at least once
//    in that session.
// 3. Fourth Activity: A "Gratitude Journal Activity" was added beyond the three
//    required activities, guiding users through gratitude-focused journaling prompts.

class Program
{
    static void Main(string[] args)
    {
        // Activity log: tracks how many times each activity was run this session
        Dictionary<string, int> activityLog = new Dictionary<string, int>
        {
            { "Breathing", 0 },
            { "Reflecting", 0 },
            { "Listing", 0 },
            { "Gratitude", 0 }
        };

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine($"  1. Start Breathing Activity    (completed: {activityLog["Breathing"]}x)");
            Console.WriteLine($"  2. Start Reflecting Activity   (completed: {activityLog["Reflecting"]}x)");
            Console.WriteLine($"  3. Start Listing Activity      (completed: {activityLog["Listing"]}x)");
            Console.WriteLine($"  4. Start Gratitude Activity    (completed: {activityLog["Gratitude"]}x)");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    activityLog["Breathing"]++;
                    break;

                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    activityLog["Reflecting"]++;
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    activityLog["Listing"]++;
                    break;

                case "4":
                    GratitudeActivity gratitude = new GratitudeActivity();
                    gratitude.Run();
                    activityLog["Gratitude"]++;
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}