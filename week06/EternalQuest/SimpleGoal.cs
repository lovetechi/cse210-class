using System;

public class SimpleGoal : Goal
{
    private bool _completed = false;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        if (_completed) return 0;
        _completed = true;
        return Points;
    }

    public override bool IsComplete()
    {
        return _completed;
    }

    public override string GetStatusString()
    {
        return string.Format("[{0}] {1} ({2} pts)", _completed ? "X" : " ", Name, Points);
    }

    public override string ToDataString()
    {
        // SIMPLE|name|description|points|completedFlag
        return $"SIMPLE|{Name}|{Description}|{Points}|{(_completed ? 1 : 0)}";
    }

    // Helpers for loading
    public void ForceComplete()
    {
        _completed = true;
    }
}
