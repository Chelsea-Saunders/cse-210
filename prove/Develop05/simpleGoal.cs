using System;

public class SimpleGoal : Goal
{
    //constructor
    public SimpleGoal(string goalName, string description, int points) 
        : base (goalName, description, points)
        {
        }
    public override string DisplayGoal()
    {
        string status = _completed ? "[X]" : "[ ]";
        return $"{status} {_goalName} ({_description})"; 
    }
    public override int PointsReceived()
    {
        return _completed ? _points : 0;
    }
    public override string RecordEvent()
{
    if (!_completed)
    {
        _completed = true; // Mark as completed
        string message = $"{_goalName} completed! You earned {_points} points.";

        // Check if all goals are completed
        if (Program.AllGoalsCompleted(Program.goalsList))
        {
            message += $@"

        .''.       🎇
        :_\\/_:  
     .-'(_🎉_)'-.
        :_\\/_:
        .'  '.
*** Congratulations! All goals are completed! ***
You earned a bonus of 1000 points!
";

            Program.points += 1000; // Add the bonus to total points
        }

        return message;
    }
    return $"{_goalName} is already completed.";
}
    public override string ToString()
    {
        return base.ToString();
    }
}