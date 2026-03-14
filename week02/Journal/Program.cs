using System;

// Exceeding Core Requirements: 
// Added a "Search by Keyword" feature (Option 5 in the menu).
// This allows the user to search through all loaded journal entries for a specific word or phrase.
// It iterates through the entries and displays only those where the date, prompt, or text contains the keyword.

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool isRunning = true;

        Console.WriteLine("Welcome to the Journal Program!");

        while (isRunning)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Search by Keyword");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");
            
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"Prompt: {prompt}");
                Console.Write("> ");
                string response = Console.ReadLine();

                Entry newEntry = new Entry();
                // Using standard date formatting per typical requirements
                newEntry._date = DateTime.Now.ToShortDateString();
                newEntry._promptText = prompt;
                newEntry._entryText = response;

                journal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                try 
                {
                    journal.LoadFromFile(filename);
                    Console.WriteLine("Journal loaded successfully.\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error loading file: {e.Message}\n");
                }
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                try
                {
                    journal.SaveToFile(filename);
                    Console.WriteLine("Journal saved successfully.\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error saving file: {e.Message}\n");
                }
            }
            else if (choice == "5")
            {
                Console.Write("Enter a keyword to search for: ");
                string keyword = Console.ReadLine();
                journal.SearchByKeyword(keyword);
                Console.WriteLine();
            }
            else if (choice == "6")
            {
                isRunning = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.\n");
            }
        }
    }
}