using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _random = new Random();

    public ReflectionActivity() : base("Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    protected override void RunActivity()
    {
        // pick a random prompt
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Console.WriteLine();

        int duration = DurationSeconds;
        Stopwatch sw = Stopwatch.StartNew();

        // we will avoid repeating questions until we've used all
        var remaining = new List<string>(_questions);

        while (sw.Elapsed.TotalSeconds < duration)
        {
            if (remaining.Count == 0)
            {
                remaining = new List<string>(_questions);
            }
            int idx = _random.Next(remaining.Count);
            string question = remaining[idx];
            remaining.RemoveAt(idx);

            Console.WriteLine(question);
            // spinner pause for reflection (6 seconds or remaining time)
            int pause = 6;
            double remainingTime = duration - sw.Elapsed.TotalSeconds;
            if (remainingTime < pause) pause = Math.Max(1, (int)Math.Ceiling(remainingTime));
            PauseWithSpinner(pause);
            Console.WriteLine();
        }

        sw.Stop();
    }
}
