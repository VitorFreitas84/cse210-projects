// Program.cs
using System;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create an instance of the ScriptureManager class
        ScriptureManager scriptureManager = new ScriptureManager();

        // Start the scripture memorization process
        scriptureManager.StartMemorization();
    }
}

class ScriptureManager
{
    private Scripture scripture;

    public void StartMemorization()
    {
        // Initialize the scripture with reference and text
        scripture = new Scripture("John 3:16", "For God so loved the world...");

        // Display the complete scripture
        Console.WriteLine(scripture.GetFullScripture());

        // Memorization loop
        while (!scripture.AllWordsHidden)
        {
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
                break;

            // Hide a few random words and display the updated scripture
            scripture.HideRandomWords();
            Console.Clear();
            Console.WriteLine(scripture.GetHiddenScripture());
        }

        Console.WriteLine("Memorization complete. Press Enter to exit.");
        Console.ReadLine();
    }
}

class Scripture
{
    private ScriptureReference reference;
    private List<ScriptureWord> words;

    public bool AllWordsHidden => words.All(word => word.IsHidden);

    public Scripture(string referenceText, string scriptureText)
    {
        reference = new ScriptureReference(referenceText);
        words = ParseScriptureText(scriptureText);
    }

    public string GetFullScripture()
    {
        return $"{reference.GetReference()} {GetScriptureText()}";
    }

    public string GetHiddenScripture()
    {
        return $"{reference.GetReference()} {GetHiddenText()}";
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = 3; // Adjust the number of words to hide as needed

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(words.Count);
            words[index].IsHidden = true;
        }
    }

    private List<ScriptureWord> ParseScriptureText(string scriptureText)
    {
        string[] wordsArray = scriptureText.Split(' ');
        return wordsArray.Select(word => new ScriptureWord(word)).ToList();
    }

    private string GetScriptureText()
    {
        return string.Join(" ", words.Select(word => word.ToString()));
    }

    private string GetHiddenText()
    {
        return string.Join(" ", words.Where(word => word.IsHidden).Select(word => word.ToString()));
    }
}

// ScriptureReference.cs
class ScriptureReference
{
    private string reference;

    public ScriptureReference(string referenceText)
    {
        reference = referenceText;
    }

    public string GetReference()
    {
        return reference;
    }
}

// ScriptureWord.cs
class ScriptureWord
{
    private string word;

    public bool IsHidden { get; set; }

    public ScriptureWord(string word)
    {
        this.word = word;
        IsHidden = false; // You might want to initialize it based on your requirements
    }

    public override string ToString()
    {
        return IsHidden ? "_____" : word;
    }
}
