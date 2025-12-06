using System;

public class ChecklistGoal : Goal
{
    private int _current;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _current = 0;
        _target = Math.Max(1, target);
        _bonus = Math.Max(0, bonus);
    }

    public override int RecordEvent()
    {
        if (_current >= _target) return 0; // already completed
        _current++;
        int awarded = Points;
        if (_current >= _target)
        {
            awarded += _bonus;
        }
        return awarded;
    }

    public override bool IsComplete()
    {
        return _current >= _target;
    }

    public override string GetStatusString()
    {
        return string.Format("[{0}] {1} ({2} pts) -- Completed {3}/{4}", IsComplete() ? "X" : " ", Name, Points, _current, _target);
    }

    public override string ToDataString()
    {
        // CHECKLIST|name|description|points|current|target|bonus
        return $"CHECKLIST|{Name}|{Description}|{Points}|{_current}|{_target}|{_bonus}";
    }

    // Helpers for loading
    public void ForceProgress(int current)
    {
        _current = Math.Max(0, current);
    }
}
