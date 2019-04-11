using System;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class TrackerAttribute : Attribute
{
    private readonly string _trackingName;

    public TrackerAttribute(string trackingName)
    {
        _trackingName = trackingName;
    }

    public string TrackingName
    {
        get { return _trackingName; }
    }
}