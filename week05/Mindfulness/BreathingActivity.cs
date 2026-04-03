using System;
using System.Collections.Generic;

class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        bool breatheIn = true;
        while (DateTime.Now < endTime)
        {
            if (breatheIn)
            {
                Console.Write("Breathe in...");
            }
            else
            {
                Console.Write("Breathe out...");
            }

            int secondsLeft = (int)(endTime - DateTime.Now).TotalSeconds;
            int pauseSeconds = Math.Min(4, secondsLeft);
            if (pauseSeconds <= 0) break;

            ShowCountdown(pauseSeconds);
            Console.WriteLine();
            breatheIn = !breatheIn;
        }

        DisplayEndingMessage();
    }
}
