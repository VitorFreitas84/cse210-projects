using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}

class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Display Player Info");
            Console.WriteLine("2. List Goal Names");
            Console.WriteLine("3. List Goal Details");
            Console.WriteLine("4. Create Goal");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Show Goals");
            Console.WriteLine("7. Save Goals");
            Console.WriteLine("8. Load Goals");
            Console.WriteLine("9. Exit");

            Console.Write("Select an option: ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    DisplayPlayerInfo();
                    break;
                case 2:
                    ListGoalNames();
                    break;
                case 3:
                    ListGoalDetails();
                    break;
                case 4:
                    CreateGoal();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    ShowGoals();
                    break;
                case 7:
                    SaveGoals();
                    break;
                case 8:
                    LoadGoals();
                    break;
                case 9:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"Player Score: {_score}");
        Console.WriteLine();
    }

    private void ListGoalNames()
    {
        Console.WriteLine("Goals:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetShortName());
        }
        Console.WriteLine();
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("Goal Details:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
        Console.WriteLine();
    }

    private void CreateGoal()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points for completing the goal: ");
        int points = int.Parse(Console.ReadLine());
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter choice: ");
        int choice = int.Parse(Console.ReadLine());

        Goal goal;
        switch (choice)
        {
            case 1:
                goal = new SimpleGoal(name, description, points);
                break;
            case 2:
                goal = new EternalGoal(name, description, points);
                break;
            case 3:
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        _goals.Add(goal);
        Console.WriteLine("Goal created successfully.");
        Console.WriteLine();
    }

    private void RecordEvent()
    {
        Console.WriteLine("Select goal to record event:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
        Console.Write("Enter choice: ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < _goals.Count)
        {
            _goals[choice].RecordEvent();
            _score += _goals[choice].Points;
            Console.WriteLine("Event recorded successfully.");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
        Console.WriteLine();
    }

    private void ShowGoals()
    {
        Console.WriteLine("Goals:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal);
        }
        Console.WriteLine();
    }

    private void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }
        Console.WriteLine("Goals saved successfully.");
        Console.WriteLine();
    }

    private void LoadGoals()
    {
        _goals.Clear();
        using (StreamReader reader = new StreamReader("goals.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Goal goal = Goal.Deserialize(line);
                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }
        }
        Console.WriteLine("Goals loaded successfully.");
        Console.WriteLine();
    }
}

abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public string GetShortName()
    {
        return _shortName;
    }

    public abstract void RecordEvent();

    public abstract string GetDetailsString();

    public int Points
    {
        get { return _points; }
    }

    public virtual string Serialize()
    {
        return $"{_shortName},{_description},{_points}";
    }

    public static Goal Deserialize(string data)
    {
        string[] parts = data.Split(',');
        if (parts.Length == 3)
        {
            string shortName = parts[0];
            string description = parts[1];
            int points = int.Parse(parts[2]);
            return new SimpleGoal(shortName, description, points);
        }
        return null;
    }

    public override string ToString()
    {
        return $"{_shortName} - {_description}";
    }
}

class SimpleGoal : Goal
{
    public SimpleGoal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public override void RecordEvent()
    {
        // For simple goals, recording an event is not applicable
    }

    public override string GetDetailsString()
    {
        return $"{_shortName} - {_description}";
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public override void RecordEvent()
    {
        // For eternal goals, recording an event is not applicable
    }

    public override string GetDetailsString()
    {
        return $"{_shortName} - {_description}";
    }
}

class ChecklistGoal : Goal
{
    private int _completedCount;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
        _target = target;
        _bonus = bonus;
        _completedCount = 0;
    }

    public override void RecordEvent()
    {
        _completedCount++;
        if (_completedCount == _target)
        {
            _points += _bonus;
        }
    }

    public override string GetDetailsString()
    {
        return $"{_shortName} - {_description} (Completed {_completedCount}/{_target} times)";
    }

    public override string Serialize()
    {
        return $"{base.Serialize()},{_target},{_bonus},{_completedCount}";
    }

    public new static Goal Deserialize(string data)
    {
        string[] parts = data.Split(',');
        if (parts.Length == 6)
        {
            string shortName = parts[0];
            string description = parts[1];
            int points = int.Parse(parts[2]);
            int target = int.Parse(parts[3]);
            int bonus = int.Parse(parts[4]);
            int completedCount = int.Parse(parts[5]);
            ChecklistGoal goal = new ChecklistGoal(shortName, description, points, target, bonus);
            goal._completedCount = completedCount;
            return goal;
        }
        return null;
    }
}


//Vitor H S Freitas