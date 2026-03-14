using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                // Using ~~ as delimiter to avoid conflicts with commas that might be in the entry text
                outputFile.WriteLine($"{entry._date}~~{entry._promptText}~~{entry._entryText}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();
        string[] lines = System.IO.File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split(new string[] { "~~" }, StringSplitOptions.None);
            if (parts.Length == 3)
            {
                Entry entry = new Entry();
                entry._date = parts[0];
                entry._promptText = parts[1];
                entry._entryText = parts[2];
                _entries.Add(entry);
            }
        }
    }

    public void SearchByKeyword(string keyword)
    {
        bool foundMatch = false;
        string lowerKeyword = keyword.ToLower();

        Console.WriteLine($"\nSearch Results for '{keyword}':");
        Console.WriteLine("----------------------------------");

        foreach (Entry entry in _entries)
        {
            if (entry._date.ToLower().Contains(lowerKeyword) || 
                entry._promptText.ToLower().Contains(lowerKeyword) || 
                entry._entryText.ToLower().Contains(lowerKeyword))
            {
                entry.Display();
                foundMatch = true;
            }
        }

        if (!foundMatch)
        {
            Console.WriteLine("No entries found containing that keyword.");
        }
    }
}
