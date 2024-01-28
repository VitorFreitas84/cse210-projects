using System;
using System.Collections.Generic;
using System.Linq;

public class ScriptureWord
{
    public string Word { get; set; }
    public bool IsHidden { get; set; }

    public ScriptureWord(string word)
    {
        Word = word;
        IsHidden = false;
    }
}

public class ScriptureReference
{
    public string Book { get; }
    public int Chapter { get; }
    public int VerseStart { get; }
    public int VerseEnd { get; }

    public ScriptureReference(string book, int chapter, int verseStart, int verseEnd = 0)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd;
    }
}

public class Scripture
{
    private readonly List<ScriptureWord> words;

    public ScriptureReference Reference { get; }
    public IReadOnlyList<ScriptureWord> Words => words;

    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        words = text.Split(' ').Select(word => new ScriptureWord(word)).ToList();
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();

        for (int i = 0; i < count; i++)
        {
            int index = random.Next(words.Count);
            words[index].IsHidden = true;
        }
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine($"Scripture Reference: {Reference.Book} {Reference.Chapter}:{Reference.VerseStart}-{Reference.VerseEnd}");

        foreach (var word in words)
        {
            if (word.IsHidden)
                Console.Write("____ ");
            else
                Console.Write($"{word.Word} ");
        }

        Console.WriteLine("\n\nPress Enter to continue or type 'quit' to exit.");
    }
}

class Program
{
    static void Main()
    {
        // Example usage for John 3:16
        ScriptureReference john316Reference = new ScriptureReference("John", 3, 16);
        string john316Text = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        Scripture john316Scripture = new Scripture(john316Reference, john316Text);

        // Example usage for Proverbs 3:5-6
        ScriptureReference prov35Reference = new ScriptureReference("Proverbs", 3, 5, 6);
        string prov35Text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        Scripture prov35Scripture = new Scripture(prov35Reference, prov35Text);

        while (john316Scripture.Words.Any(word => !word.IsHidden) || prov35Scripture.Words.Any(word => !word.IsHidden))
        {
            john316Scripture.Display();
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
                break;

            john316Scripture.HideRandomWords(2);
        }

        Console.WriteLine("\n\n---\n\n");

        while (prov35Scripture.Words.Any(word => !word.IsHidden))
        {
            prov35Scripture.Display();
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
                break;

            prov35Scripture.HideRandomWords(2);
        }
    }
}

