using System;
using System.Diagnostics;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _durationSeconds;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _durationSeconds = 0;
    }

    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
    public int DurationSeconds { get { return _durationSeconds; } }

    // Ask the user to set the duration (in seconds)
    public void SetDurationFromUser()
    {
        Console.Write($"Enter duration in seconds for the {_name}: ");
        string input = Console.ReadLine();
        int seconds = 0;
        if (!int.TryParse(input, out seconds) || seconds <= 0)
        {
            Console.WriteLine("Invalid duration; using default of 30 seconds.");
            seconds = 30;
        }
        _durationSeconds = seconds;
    }

    public void Start()
    {
        DisplayStartingMessage();
        Console.WriteLine("Get ready...");
        PauseWithSpinner(3);
        RunActivity();
        DisplayEndingMessage();
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"=== {Name} ===");
        Console.WriteLine(Description);
        Console.WriteLine();
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have completed the {Name} for {DurationSeconds} seconds.");
        PauseWithSpinner(3);
    }

    // Basic spinner animation for a number of seconds
    protected void PauseWithSpinner(int seconds)
    {
        string[] spinner = new string[] { "|", "/", "-", "\\" };
        Stopwatch sw = Stopwatch.StartNew();
        int i = 0;
        while (sw.Elapsed.TotalSeconds < seconds)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write('\b');
            i++;
        }
        sw.Stop();
    }

    // Countdown display (seconds)
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write('\r');
            Console.Write(new string(' ', i.ToString().Length));
            Console.Write('\r');
        }
    }

    // Run the concrete activity logic; subclasses implement
    protected abstract void RunActivity();
}
