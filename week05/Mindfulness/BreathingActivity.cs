using System;
using System.Diagnostics;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void RunActivity()
    {
        int duration = DurationSeconds;
        Stopwatch sw = Stopwatch.StartNew();
        bool inhale = true;
        while (sw.Elapsed.TotalSeconds < duration)
        {
            if (inhale)
            {
                Console.WriteLine("Breathe in...");
            }
            else
            {
                Console.WriteLine("Breathe out...");
            }
            // show a short countdown (4 seconds) or remaining time if shorter
            int pause = 4;
            double remaining = duration - sw.Elapsed.TotalSeconds;
            if (remaining < pause) pause = Math.Max(1, (int)Math.Ceiling(remaining));
            ShowCountdown(pause);
            inhale = !inhale;
            Console.WriteLine();
        }
        sw.Stop();
    }
}
