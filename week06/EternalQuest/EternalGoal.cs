using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        // never completes; always awards points
        return Points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStatusString()
    {
        return string.Format("[~] {0} ({1} pts per record)", Name, Points);
    }

    public override string ToDataString()
    {
        return $"ETERNAL|{Name}|{Description}|{Points}";
    }
}
