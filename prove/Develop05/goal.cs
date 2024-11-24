using System;

public abstract class Goal
{
    protected string _goalName;
    protected string _description;
    protected int _points;
    protected bool _completed;

    //constructor
    public Goal(string goalName, string description, int points)
    {
        _goalName = goalName;
        _description = description;
        _points = points;
        _completed = false;
    }
    public bool Completed 
    {
        get => _completed;
        set => _completed = value;
    }
    public override string ToString()
    {
        return $"{this.GetType().Name}|{_goalName}|{_description}|{_points}|{_completed}";
    }

    public virtual string DisplayGoal()
    {
        string status = _completed ? "[X]" : "[ ]";//determine if goal is completed
        return$"{status} {_goalName} ({_description}) (Points: {_points})"; //Completed: {_completed}
    }
    public virtual int PointsReceived()
    {
        return _points;
    }
    public virtual string RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
            return $"{_goalName} completed!! You earned {_points} points.";
        }
        return $"{_goalName} is already completed";
    }
}