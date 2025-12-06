using System;

public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
    public int Points { get { return _points; } }

    // Returns points awarded when the goal is recorded at this time (may be zero)
    public abstract int RecordEvent();

    // Whether the goal is complete (some goals like eternal goals are never complete)
    public abstract bool IsComplete();

    // Short status string for listing (e.g., [X] or [ ] plus details)
    public abstract string GetStatusString();

    // Serialize to a line for saving
    public abstract string ToDataString();

    // Factory to create a Goal from saved data
    public static Goal FromDataString(string line)
    {
        // Format: Type|name|description|points|... (type-specific fields follow)
        var parts = line.Split('|');
        if (parts.Length < 4) throw new Exception("Invalid data line");
        string type = parts[0];
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);

        if (type == "SIMPLE")
        {
            bool completed = parts.Length > 4 && parts[4] == "1";
            var g = new SimpleGoal(name, description, points);
            if (completed) g.ForceComplete();
            return g;
        }
        else if (type == "ETERNAL")
        {
            return new EternalGoal(name, description, points);
        }
        else if (type == "CHECKLIST")
        {
            // expected extra fields: currentCount, targetCount, bonus
            int current = parts.Length > 4 ? int.Parse(parts[4]) : 0;
            int target = parts.Length > 5 ? int.Parse(parts[5]) : 1;
            int bonus = parts.Length > 6 ? int.Parse(parts[6]) : 0;
            var g = new ChecklistGoal(name, description, points, target, bonus);
            g.ForceProgress(current);
            return g;
        }
        else
        {
            throw new Exception("Unknown goal type: " + type);
        }
    }
}
