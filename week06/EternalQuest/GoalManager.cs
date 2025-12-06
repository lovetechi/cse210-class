using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public int Score { get { return _score; } }

    public void AddGoal(Goal g)
    {
        _goals.Add(g);
    }

    public IReadOnlyList<Goal> GetGoals()
    {
        return _goals.AsReadOnly();
    }

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals defined.");
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i+1}. {_goals[i].GetStatusString()}");
        }
    }

    public void RecordEvent(int index)
    {
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal index.");
            return;
        }
        var g = _goals[index];
        int gained = g.RecordEvent();
        _score += gained;
        Console.WriteLine($"You gained {gained} points. Total score: {_score}");
    }

    public void Save(string filename)
    {
        using (var writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (var g in _goals)
            {
                writer.WriteLine(g.ToDataString());
            }
        }
    }

    public void Load(string filename)
    {
        var lines = File.ReadAllLines(filename);
        if (lines.Length == 0) return;
        int parsedScore = 0;
        if (!int.TryParse(lines[0], out parsedScore)) parsedScore = 0;
        _score = parsedScore;
        _goals.Clear();
        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;
            var g = Goal.FromDataString(lines[i]);
            _goals.Add(g);
        }
    }
}
