using System;

public class RunningActivity : Activity
{
    private double _distanceMiles;

    public RunningActivity(DateTime date, int minutes, double distanceMiles) : base(date, minutes, "Running")
    {
        _distanceMiles = distanceMiles;
    }

    public override double GetDistance()
    {
        return _distanceMiles;
    }

    public override double GetSpeed()
    {
        // mph = distance (miles) / hours
        double hours = Minutes / 60.0;
        if (hours <= 0) return 0;
        return _distanceMiles / hours;
    }

    public override double GetPace()
    {
        // minutes per mile
        if (_distanceMiles <= 0) return 0;
        return Minutes / _distanceMiles;
    }
}
