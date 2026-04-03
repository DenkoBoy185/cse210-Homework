using System;
using System.Threading;

class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public string Name
    {
        get { return _name; }
    }

    public int Duration
    {
        get { return _duration; }
    }

    // Displays the common starting message and prompts for duration
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.Clear();
    }

    // Displays the common ending message
    public void DisplayEndingMessage()
    {
        Console.Clear();
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(5);
    }

    // Shows a spinner animation for a given number of seconds
    public void ShowSpinner(int seconds)
    {
        char[] spinnerChars = { '|', '/', '-', '\\' };
        int totalIterations = seconds * 4; // 4 frames per second (250ms each)
        Console.Write(" ");
        for (int i = 0; i < totalIterations; i++)
        {
            Console.Write(spinnerChars[i % spinnerChars.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    // Shows a countdown timer from a given number of seconds down to 0
    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            // Erase the digit(s) using backspaces
            int digits = i.ToString().Length;
            for (int d = 0; d < digits; d++)
            {
                Console.Write("\b \b");
            }
        }
    }
}
