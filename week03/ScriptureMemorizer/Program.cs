using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Exceeding Requirements: 
        // 1. We load a list of different scriptures and randomly pick one to display to the user.
        // 2. In Scripture.cs, we specifically only select random visible words to hide, so the random picker 
        //    never wastes a turn trying to hide an already hidden word.

        List<Scripture> scriptures = new List<Scripture>();
        
        scriptures.Add(new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."));
        scriptures.Add(new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));
        scriptures.Add(new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me."));
        scriptures.Add(new Scripture(new Reference("Ether", 12, 27), "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men that humble themselves before me; for if they humble themselves before me, and have faith in me, then will I make weak things become strong unto them."));

        Random random = new Random();
        int randomIndex = random.Next(scriptures.Count);
        Scripture selectedScripture = scriptures[randomIndex];

        while (true)
        {
            if (!Console.IsOutputRedirected)
            {
                try { Console.Clear(); } catch { }
            }
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            
            string input = Console.ReadLine();
            
            if (input?.ToLower() == "quit")
            {
                break;
            }

            if (selectedScripture.IsCompletelyHidden())
            {
                break;
            }

            // Hide 3 random words each time
            selectedScripture.HideRandomWords(3);
        }
    }
}