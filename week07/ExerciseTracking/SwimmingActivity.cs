using System;

public class SwimmingActivity : Activity
{
    private int _laps; // 50 meters per lap

    public SwimmingActivity(DateTime date, int minutes, int laps) : base(date, minutes, "Swimming")
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Convert laps to miles: laps * 50 meters -> km -> miles
        double km = _laps * 50.0 / 1000.0;
        double miles = km * 0.62;
        return miles;
    }

    public override double GetSpeed()
    {
        double hours = Minutes / 60.0;
        double dist = GetDistance();
        if (hours <= 0) return 0;
        return dist / hours;
    }

    public override double GetPace()
    {
        double dist = GetDistance();
        if (dist <= 0) return 0;
        return Minutes / dist; // minutes per mile
    }
}
