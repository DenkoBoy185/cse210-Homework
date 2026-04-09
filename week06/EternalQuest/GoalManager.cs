using System;
using System.Collections.Generic;
using System.IO;

// Controls the list of goals, the user's score, and save/load operations.
class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // ── Score / Level ────────────────────────────────────────────────────────

    public int Score => _score;

    // EXCEEDS REQUIREMENTS: Leveling System
    // As the user earns more points they are promoted through adventurer ranks.
    public string GetLevel()
    {
        if (_score >= 10000) return "Legend";
        if (_score >= 5000)  return "Champion";
        if (_score >= 2000)  return "Hero";
        if (_score >= 1000)  return "Adventurer";
        if (_score >= 500)   return "Journeyman";
        if (_score >= 200)   return "Apprentice";
        return "Novice";
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\nYou have {_score} points. Level: {GetLevel()}");
    }

    // ── Goals ────────────────────────────────────────────────────────────────

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals yet. Create one first!");
            return;
        }
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (bad habit — deducts points)");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("\nWhat is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;

            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;

            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int required = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, required, bonus));
                break;

            case "4":
                _goals.Add(new NegativeGoal(name, description, points));
                break;

            default:
                Console.WriteLine("Invalid choice. No goal created.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals to record. Create one first!");
            return;
        }

        DisplayGoals();
        Console.Write("\nWhich goal did you accomplish? (enter number) ");
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Goal goal = _goals[index - 1];

        if (goal.IsComplete)
        {
            Console.WriteLine($"\n\"{goal.Name}\" is already complete! Move on to new goals!");
            return;
        }

        int earned = goal.RecordEvent();
        _score += earned;

        if (earned > 0)
        {
            Console.WriteLine($"\nCongratulations! You have earned {earned} points!");
            if (goal.IsComplete)
            {
                Console.WriteLine(">>> Goal Complete! Amazing work! <<<");
            }
        }
        else if (earned < 0)
        {
            Console.WriteLine($"\nOh no! You lost {Math.Abs(earned)} points for that bad habit. You can do better!");
        }

        Console.WriteLine($"You now have {_score} points. Level: {GetLevel()}");
    }

    // ── Save / Load ──────────────────────────────────────────────────────────

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine($"\nGoals saved to '{filename}'.");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"\nFile '{filename}' not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);

        // First line is the score
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            // Split into type and data on the first colon
            int colonIndex = line.IndexOf(':');
            string type = line.Substring(0, colonIndex);
            string data = line.Substring(colonIndex + 1);
            string[] parts = data.Split(',');

            Goal goal = null;
            switch (type)
            {
                case "SimpleGoal":
                    goal = new SimpleGoal(parts[0], parts[1], int.Parse(parts[2]));
                    if (bool.Parse(parts[3]))
                    {
                        goal.RecordEvent(); // mark it complete
                    }
                    break;

                case "EternalGoal":
                    goal = new EternalGoal(parts[0], parts[1], int.Parse(parts[2]));
                    break;

                case "ChecklistGoal":
                    int checkPoints = int.Parse(parts[2]);
                    int bonusVal    = int.Parse(parts[3]);
                    int current     = int.Parse(parts[4]);
                    int required    = int.Parse(parts[5]);
                    goal = new ChecklistGoal(parts[0], parts[1], checkPoints, required, bonusVal);
                    // Re-record events silently to restore progress
                    for (int j = 0; j < current; j++)
                    {
                        goal.RecordEvent();
                    }
                    break;

                case "NegativeGoal":
                    goal = new NegativeGoal(parts[0], parts[1], int.Parse(parts[2]));
                    break;
            }

            if (goal != null)
            {
                _goals.Add(goal);
            }
        }

        Console.WriteLine($"\nGoals loaded from '{filename}'. Welcome back, {GetLevel()}!");
    }
}
