using System;

// ============================================================
// W06 Eternal Quest Program — Program.cs
// ============================================================
// This program exceeds the core requirements in two ways:
//
// 1. NEGATIVE GOALS: A fourth goal type (NegativeGoal) represents
//    bad habits. Recording one DEDUCTS points from the score,
//    acting as a deterrent to help the user stop bad habits.
//    (See NegativeGoal.cs)
//
// 2. LEVELING SYSTEM: The user earns "adventurer" rank titles
//    (Novice → Apprentice → Journeyman → Adventurer → Hero →
//     Champion → Legend) based on their total score. The current
//    level is displayed alongside the score after every event and
//    on the score screen, encouraging continued engagement.
//    (See GoalManager.GetLevel())
// ============================================================

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        Console.WriteLine("=== Welcome to the Eternal Quest ===");

        while (running)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Display Player Score");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Create New Goal");
            Console.WriteLine("  4. Record Event");
            Console.WriteLine("  5. Save Goals");
            Console.WriteLine("  6. Load Goals");
            Console.WriteLine("  7. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.DisplayScore();
                    break;

                case "2":
                    manager.DisplayGoals();
                    break;

                case "3":
                    manager.CreateGoal();
                    break;

                case "4":
                    manager.RecordEvent();
                    break;

                case "5":
                    Console.Write("\nWhat is the filename for the goal file? ");
                    string saveFile = Console.ReadLine();
                    manager.SaveGoals(saveFile);
                    break;

                case "6":
                    Console.Write("\nWhat is the filename for the goal file? ");
                    string loadFile = Console.ReadLine();
                    manager.LoadGoals(loadFile);
                    break;

                case "7":
                    running = false;
                    Console.WriteLine("\nFarewell, brave soul. Keep up the Quest!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}