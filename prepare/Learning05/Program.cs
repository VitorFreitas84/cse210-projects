using System;
using System.Collections.Generic;
using System.IO;

// Base class to represent a goal
public abstract class Goal
{
    public int Id { get; }
    public string Description { get; }
    public bool Completed { get; private set; }

    public Goal(int id, string description)
    {
        Id = id;
        Description = description;
        Completed = false;
    }

    // Abstract method to get the points of the goal
    public abstract int GetPoints();

    // Marks the goal as completed
    public void Complete()
    {
        Completed = true;
    }

    // Method to format the goal as a string
    public override string ToString()
    {
        return $"[{(Completed ? "X" : " ")}] {Description}";
    }
}

// Represents a simple goal that can be marked as completed
public class SimpleGoal : Goal
{
    private int points; // Points associated with the goal

    public SimpleGoal(int id, string description, int points) : base(id, description)
    {
        this.points = points;
    }

    // Returns the points of the goal
    public override int GetPoints()
    {
        return points;
    }
}

// Represents an eternal goal that is never completed
public class EternalGoal : Goal
{
    private int points; // Points associated with the goal

    public EternalGoal(int id, string description, int points) : base(id, description)
    {
        this.points = points;
    }

    // Returns the points of the goal
    public override int GetPoints()
    {
        return points;
    }
}

// Represents a checklist goal that must be completed a certain number of times
public class ChecklistGoal : Goal
{
    private int completionCount; // Completion count of the goal
    private int targetCount; // Target number of completions
    private int bonusPoints; // Bonus points upon reaching the target count

    public ChecklistGoal(int id, string description, int targetCount, int bonusPoints) : base(id, description)
    {
        this.targetCount = targetCount;
        this.bonusPoints = bonusPoints;
    }

    // Returns the points of the goal
    public override int GetPoints()
    {
        int points = completionCount * GetCompletionPoints() + (IsComplete() ? bonusPoints : 0);
        return points;
    }

    // Increments the completion count of the goal
    public void IncrementCompletionCount()
    {
        completionCount++;
    }

    // Checks if the goal is complete
    public bool IsComplete()
    {
        return completionCount >= targetCount;
    }

    // Calculates the completion points of the goal
    private int GetCompletionPoints()
    {
        return targetCount > 0 ? 1 : 0; // At the moment, we are assigning only 1 point per completion
    }
}

// Represents the Eternal Quest program that tracks and manages goals
public class EternalQuest
{
    private List<Goal> goals = new List<Goal>(); // List of goals
    private int totalPoints = 0; // User's total score

    // Adds a new goal to the program
    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    // Marks a goal as completed and updates the user's total score
    public void CompleteGoal(int goalId)
    {
        Goal goal = goals.Find(g => g.Id == goalId);
        if (goal != null && !goal.Completed)
        {
            goal.Complete();
            totalPoints += goal.GetPoints();
            if (goal is ChecklistGoal checklistGoal)
            {
                checklistGoal.IncrementCompletionCount();
            }
        }
    }

    // Displays all user's goals
    public void DisplayGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine(goal);
        }
    }

    // Displays the user's total score
    public void DisplayScore()
    {
        Console.WriteLine($"Total Points: {totalPoints}");
    }

    // Saves the user's goals and score to a file
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name},{goal.Id},{goal.Description},{goal.Completed}");
            }
        }
    }

    // Loads the user's goals and score from a file
    public void LoadFromFile(string filename)
    {
        goals.Clear();
        totalPoints = 0;
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                string typeName = parts[0];
                int id = int.Parse(parts[1]);
                string description = parts[2];
                bool completed = bool.Parse(parts[3]);

                Goal goal;
                switch (typeName)
                {
                    case nameof(SimpleGoal):
                        goal = new SimpleGoal(id, description, 0);
                        break;
                    case nameof(EternalGoal):
                        goal = new EternalGoal(id, description, 0);
                        break;
                    case nameof(ChecklistGoal):
                        goal = new ChecklistGoal(id, description, 0, 0);
                        break;
                    default:
                        throw new ArgumentException("Invalid goal type in file.");
                }

                goal.Complete();
                if (!completed)
                    goal.Complete();

                goals.Add(goal);
                totalPoints += goal.GetPoints();
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of EternalQuest
        EternalQuest eternalQuest = new EternalQuest();

        // Example usage
        eternalQuest.AddGoal(new SimpleGoal(1, "Run a marathon", 1000));
        eternalQuest.AddGoal(new EternalGoal(2, "Read scriptures", 100));
        eternalQuest.AddGoal(new ChecklistGoal(3, "Attend the temple", 10, 50));

        eternalQuest.DisplayGoals();

        eternalQuest.CompleteGoal(1);
        eternalQuest.CompleteGoal(2);
        eternalQuest.CompleteGoal(3);
        eternalQuest.CompleteGoal(3);
        eternalQuest.CompleteGoal(3);

        eternalQuest.DisplayGoals();
        eternalQuest.DisplayScore();
    }
}
