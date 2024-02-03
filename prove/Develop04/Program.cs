using System;
using System.Threading;

// Base class for mindfulness activities
class MindfulnessActivity
{
    protected string activityName;
    protected string activityDescription;
    protected int durationInSeconds;

    public MindfulnessActivity(string name, string description)
    {
        activityName = name;
        activityDescription = description;
    }

    public virtual void StartActivity()
    {
        Console.WriteLine($"Starting {activityName} activity...");
        Console.WriteLine(activityDescription);

        SetDuration();
        PrepareToBegin();
        PerformActivity();
        ConcludeActivity();
    }

    protected virtual void SetDuration()
    {
        Console.Write("Enter duration in seconds: ");
        durationInSeconds = int.Parse(Console.ReadLine());
    }

    protected void PrepareToBegin()
    {
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(2000); // Pause for 2 seconds
    }

    protected void ConcludeActivity()
    {
        Console.WriteLine($"Good job! You completed {activityName} for {durationInSeconds} seconds.");
        Thread.Sleep(2000); // Pause for 2 seconds
    }

    protected virtual void PerformActivity()
    {
        // To be implemented by derived classes
    }
}

// BreathingActivity class
class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Let's start breathing...");

        for (int i = 0; i < durationInSeconds; i++)
        {
            Console.WriteLine(i % 2 == 0 ? "Breathe in..." : "Breathe out...");
            Thread.Sleep(1000); // Pause for 1 second
        }
    }
}

// ReflectionActivity class
class ReflectionActivity : MindfulnessActivity
{
    private string[] reflectionPrompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] reflectionQuestions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    protected override void PerformActivity()
    {
        Random random = new Random();
        string prompt = reflectionPrompts[random.Next(reflectionPrompts.Length)];

        Console.WriteLine($"Reflect on: {prompt}");

        foreach (var question in reflectionQuestions)
        {
            Console.WriteLine(question);
            Thread.Sleep(2000); // Pause for 2 seconds
        }
    }
}

// ListingActivity class
class ListingActivity : MindfulnessActivity
{
    private string[] listingPrompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void PerformActivity()
    {
        Random random = new Random();
        string prompt = listingPrompts[random.Next(listingPrompts.Length)];

        Console.WriteLine($"List as many as you can about: {prompt}");

        int itemsCount = 0;

        while (durationInSeconds > 0)
        {
            Console.Write("Item: ");
            Console.ReadLine(); // Assuming the user enters items one by one

            itemsCount++;
            durationInSeconds--;
        }

        Console.WriteLine($"You listed {itemsCount} items.");
    }
}

class Program
{
    static void Main()
    {
        // Sample usage
        MindfulnessActivity[] activities = {
            new BreathingActivity(),
            new ReflectionActivity(),
            new ListingActivity()
        };

        foreach (var activity in activities)
        {
            activity.StartActivity();
        }
    }
}
