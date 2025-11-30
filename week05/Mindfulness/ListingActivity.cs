using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();

    public ListingActivity() : base("Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void RunActivity()
    {
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Console.WriteLine();
        Console.WriteLine("You will have a few seconds to think, then list as many items as you can. Press Enter after each item.");
        Console.WriteLine("Get ready...");
        PauseWithSpinner(4);

        int duration = DurationSeconds;
        Stopwatch sw = Stopwatch.StartNew();

        List<string> items = new List<string>();
        while (sw.Elapsed.TotalSeconds < duration)
        {
            // check remaining time, show a small countdown to indicate time left for quick typing
            Console.Write("- ");
            // Use ReadLine with a timeout: we will poll for input until time expires
            string entry = ReadLineWithTimeout((int)Math.Ceiling(duration - sw.Elapsed.TotalSeconds));
            if (!string.IsNullOrWhiteSpace(entry))
            {
                items.Add(entry.Trim());
            }
        }

        sw.Stop();

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items:");
        foreach (var it in items)
        {
            Console.WriteLine("- " + it);
        }
    }

    // ReadLine but stop when timeoutSeconds elapsed; returns empty string if no input
    private string ReadLineWithTimeout(int timeoutSeconds)
    {
        var sw = Stopwatch.StartNew();
        string result = string.Empty;
        while (sw.Elapsed.TotalSeconds < timeoutSeconds)
        {
            if (Console.KeyAvailable)
            {
                string line = Console.ReadLine();
                return line ?? string.Empty;
            }
            Thread.Sleep(50);
        }
        return result;
    }
}
