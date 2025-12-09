using System;

public class CyclingActivity : Activity
{
    private double _speedMph; // use miles per hour as input

    public CyclingActivity(DateTime date, int minutes, double speedMph) : base(date, minutes, "Cycling")
    {
        _speedMph = speedMph;
    }

    public override double GetDistance()
    {
        // distance = speed (mph) * hours
        double hours = Minutes / 60.0;
        return _speedMph * hours;
    }

    public override double GetSpeed()
    {
        return _speedMph;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        if (distance <= 0) return 0;
        return Minutes / distance; // minutes per mile
    }
}
