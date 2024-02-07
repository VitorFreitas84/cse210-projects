using System;

// Define the User, OneTimeGoal, EternalGoal, and ChecklistGoal classes here

class Program
{
    static void Main(string[] args)
    {
        // Instantiate a User object
        User user = new User();

        // Example of a simple menu
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Eternal Quest - Menu");
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. Complete Goal");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save Progress");
            Console.WriteLine("6. Load Progress");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddGoal(user);
                    break;
                case "2":
                    CompleteGoal(user);
                    break;
                case "3":
                    user.ShowGoals();
                    break;
                case "4":
                    Console.WriteLine("Current score: " + user.Score);
                    break;
                case "5":
                    user.SaveProgress("progress.txt");
                    Console.WriteLine("Progress saved successfully!");
                    break;
                case "6":
                    user.LoadProgress("progress.txt");
                    Console.WriteLine("Progress loaded successfully!");
                    break;
                case "7":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    // Method to add a goal
    static void AddGoal(User user)
    {
        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the goal score: ");
        int points = int.Parse(Console.ReadLine());

        Console.WriteLine("Choose the goal type:");
        Console.WriteLine("1. One-time Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose an option: ");
        string typeChoice = Console.ReadLine();

        switch (typeChoice)
        {
            case "1":
                user.AddGoal(new OneTimeGoal(name, points));
                break;
            case "2":
                user.AddGoal(new EternalGoal(name, points));
                break;
            case "3":
                Console.Write("Enter the number of times this goal should be completed: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter the extra bonus score upon completing the goal: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                user.AddGoal(new ChecklistGoal(name, points, targetCount, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    // Method to complete a goal
    static void CompleteGoal(User user)
    {
        Console.Write("Enter the index of the goal you want to complete: ");
        int index = int.Parse(Console.ReadLine());
        user.CompleteGoal(index);
        Console.WriteLine("Goal completed successfully!");
    }
}
