using System;

public class EternalGoal : Goal
{
    private int _completedCount;

    //constructor
    public EternalGoal(string goalName, string description, int points) 
    : base(goalName, description, points)
    {
        _completedCount = 0;
    }
    public override string DisplayGoal()
    {
        return $"[∞] {_goalName} ({_description}) -- Total completions:{_completedCount}";
    }
    public override int PointsReceived()
    {
        return _points;
    }
    public override string RecordEvent()
    {
        _completedCount++;
        return $"{_goalName} recorded! Total completions: {_completedCount}, Points earned: {_points}";
    }
    public override string ToString()
    {
        return $"{GetType().Name}|{_goalName}|{_description}|{_points}|{_completedCount}";
    }
}