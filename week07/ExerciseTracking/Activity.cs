using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;
    private string _typeName;

    protected Activity(DateTime date, int minutes, string typeName)
    {
        _date = date;
        _minutes = minutes;
        _typeName = typeName;
    }

    public DateTime Date { get { return _date; } }
    public int Minutes { get { return _minutes; } }
    public string TypeName { get { return _typeName; } }

    // Derived classes must implement these
    public abstract double GetDistance(); // in chosen units (miles)
    public abstract double GetSpeed(); // miles per hour
    public abstract double GetPace(); // minutes per mile

    public virtual string GetSummary()
    {
        string dateStr = _date.ToString("dd MMM yyyy");
        double distance = Math.Round(GetDistance(), 2);
        double speed = Math.Round(GetSpeed(), 2);
        double pace = Math.Round(GetPace(), 2);
        return $"{dateStr} {TypeName} ({Minutes} min) - Distance {distance} miles, Speed {speed} mph, Pace: {pace} min per mile";
    }
}
