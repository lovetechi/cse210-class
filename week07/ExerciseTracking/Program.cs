using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var activities = new List<Activity>();

        activities.Add(new RunningActivity(new DateTime(2022,11,3), 30, 3.0));
        activities.Add(new CyclingActivity(new DateTime(2022,11,3), 30, 12.0));
        activities.Add(new SwimmingActivity(new DateTime(2022,11,3), 30, 60)); // 60 laps

        foreach (var a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}