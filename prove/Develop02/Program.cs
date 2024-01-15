using System;
using System.Collections.Generic;
using System.IO;

// Define the Entry class to represent journal entries
class Entry
{
    public DateTime Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
}

// Define the Journal class to manage entries
class Journal
{
    private List<Entry> entries = new List<Entry>();
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
        // Add your own prompts here
    };

    // Method to write a new entry
    public void WriteNewEntry()
    {
        // Show a random prompt
        Random random = new Random();
        string randomPrompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"Prompt: {randomPrompt}");

        // Get user's response
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        // Save the entry to the journal
        Entry entry = new Entry
        {
            Date = DateTime.Now,
            Prompt = randomPrompt,
            Response = response
        };
        entries.Add(entry);

        Console.WriteLine("Entry recorded successfully!");
    }

    // Method to display the journal entries
    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}, Prompt: {entry.Prompt}, Response: {entry.Response}");
        }
    }

    // Method to save the journal to a file
    public void SaveJournalToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                outputFile.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }

        Console.WriteLine($"Journal saved to {filename} successfully!");
    }

    // Method to load the journal from a file
    public void LoadJournalFromFile(string filename)
    {
        try
        {
            string[] lines = File.ReadAllLines(filename);
            entries.Clear();

            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                DateTime date = DateTime.Parse(parts[0]);
                string prompt = parts[1];
                string response = parts[2];

                Entry entry = new Entry
                {
                    Date = date,
                    Prompt = prompt,
                    Response = response
                };
                entries.Add(entry);
            }

            Console.WriteLine($"Journal loaded from {filename} successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}

// Program class to run the application
class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.WriteNewEntry();
                    break;

                case "2":
                    journal.DisplayJournal();
                    break;

                case "3":
                    Console.Write("Enter the filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveJournalToFile(saveFilename);
                    break;

                case "4":
                    Console.Write("Enter the filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadJournalFromFile(loadFilename);
                    break;

                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
}
