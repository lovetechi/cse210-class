using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        var manager = new GoalManager();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Eternal Quest - Main Menu");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record event (complete a goal)");
            Console.WriteLine("4. Show score");
            Console.WriteLine("5. Save goals");
            Console.WriteLine("6. Load goals");
            Console.WriteLine("7. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            Console.WriteLine();
            switch (choice)
            {
                case "1":
                    CreateNewGoal(manager);
                    break;
                case "2":
                    manager.DisplayGoals();
                    break;
                case "3":
                    RecordEvent(manager);
                    break;
                case "4":
                    Console.WriteLine($"Current score: {manager.Score.ToString("N0", CultureInfo.CurrentCulture)}");
                    break;
                case "5":
                    SaveGoals(manager);
                    break;
                case "6":
                    LoadGoals(manager);
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void CreateNewGoal(GoalManager manager)
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple goal (one-time completion)");
        Console.WriteLine("2. Eternal goal (repeatable)");
        Console.WriteLine("3. Checklist goal (complete N times)");
        Console.Write("Choice: ");
        string t = Console.ReadLine();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter points for each record: ");
        int pts = ReadIntOrDefault(10);

        if (t == "1")
        {
            manager.AddGoal(new SimpleGoal(name, desc, pts));
            Console.WriteLine("Simple goal created.");
        }
        else if (t == "2")
        {
            manager.AddGoal(new EternalGoal(name, desc, pts));
            Console.WriteLine("Eternal goal created.");
        }
        else if (t == "3")
        {
            Console.Write("Enter target count: ");
            int target = ReadIntOrDefault(5);
            Console.Write("Enter bonus points when completed: ");
            int bonus = ReadIntOrDefault(50);
            manager.AddGoal(new ChecklistGoal(name, desc, pts, target, bonus));
            Console.WriteLine("Checklist goal created.");
        }
        else
        {
            Console.WriteLine("Unknown type.");
        }
    }

    static void RecordEvent(GoalManager manager)
    {
        var goals = manager.GetGoals();
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }
        manager.DisplayGoals();
        Console.Write("Enter goal number to record: ");
        int idx = ReadIntOrDefault(0) - 1;
        manager.RecordEvent(idx);
    }

    static void SaveGoals(GoalManager manager)
    {
        Console.Write("Enter filename to save goals: ");
        string file = Console.ReadLine();
        try
        {
            manager.Save(file);
            Console.WriteLine("Saved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving: " + ex.Message);
        }
    }

    static void LoadGoals(GoalManager manager)
    {
        Console.Write("Enter filename to load goals: ");
        string file = Console.ReadLine();
        try
        {
            manager.Load(file);
            Console.WriteLine("Loaded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading: " + ex.Message);
        }
    }

    static int ReadIntOrDefault(int defaultVal)
    {
        string s = Console.ReadLine();
        int v;
        if (!int.TryParse(s, out v)) return defaultVal;
        return v;
    }
}