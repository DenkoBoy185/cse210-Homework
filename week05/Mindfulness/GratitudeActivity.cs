using System;
using System.Collections.Generic;

// CREATIVITY / EXCEEDS REQUIREMENTS:
// GratitudeActivity is a fourth activity not required by the core specifications.
// It guides users to write a short gratitude journal entry by prompting them
// with category cues (e.g., people, places, moments) one at a time.
// This broadens the mindfulness offering beyond the three core activities.
class GratitudeActivity : Activity
{
    private List<string> _cues = new List<string>
    {
        "Name a person you are grateful for today.",
        "Describe a place that brings you peace or joy.",
        "What is a small moment today that you appreciated?",
        "What is a skill or talent you are thankful to have?",
        "What is something about your health or body you are grateful for?",
        "Name something in your home that you value.",
        "Who is someone that has made a positive impact in your life?",
        "What is a challenge you are grateful for because of what it taught you?"
    };

    private List<string> _remainingCues;
    private Random _random = new Random();

    public GratitudeActivity() : base(
        "Gratitude Journal Activity",
        "This activity will guide you through a short gratitude journaling session. You will be prompted with a series of cues to help you recognize and appreciate the good things in your life.")
    {
        _remainingCues = new List<string>(_cues);
    }

    // Returns a random cue — resets pool when exhausted (exceeds core requirements)
    private string GetNextCue()
    {
        if (_remainingCues.Count == 0)
        {
            _remainingCues = new List<string>(_cues);
        }
        int index = _random.Next(_remainingCues.Count);
        string cue = _remainingCues[index];
        _remainingCues.RemoveAt(index);
        return cue;
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("Take a moment on each prompt. Write your response and press Enter.\n");
        ShowCountdown(3);
        Console.WriteLine();

        List<string> entries = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine($"\n* {GetNextCue()}");
            Console.Write("> ");
            string entry = Console.ReadLine();
            if (entry != null && entry.Trim() != "")
            {
                entries.Add(entry.Trim());
            }
        }

        Console.WriteLine($"\nWonderful! You recorded {entries.Count} gratitude entries.");
        ShowSpinner(3);

        DisplayEndingMessage();
    }
}
