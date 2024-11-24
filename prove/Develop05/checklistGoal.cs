using System;

public class ChecklistGoal : Goal
{
    private int _bonusPoints;
    private int _totalCount;
    private int _completedCount;

    //constructor
    public ChecklistGoal(string goalName, string description, int points, int bonusPoints, int totalCount) 
        : base(goalName, description, points)
    {
        _bonusPoints = bonusPoints;
        _totalCount = totalCount;
        _completedCount = 0;
    }

    public override string DisplayGoal()
    {
        string status = _completed ? "[X]" : "[ ]";
        return $"{status} {_goalName} -- Currently completed: {_completedCount}/{_totalCount}";
    }
    public override int PointsReceived()
    {
        // int totalPoints = _completedCount * _points;
        if (_completed)
        {
            return _points * _totalCount + _bonusPoints + 1000;
            // totalPoints += _bonusPoints;
        }
        return _points;
    }
    public override string RecordEvent()
    {
        if (_completedCount < _totalCount)
        {
            _completedCount++;

            if (_completedCount == _totalCount)
            {
                _completed = true;
                string message = $"{_goalName} completed! You earned {_points * _totalCount + _bonusPoints} points.";
                
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
            return $"{_goalName}: Progress recorded. {_completedCount}/{_totalCount} completed. You earned {_points}";
        }
        return $"{_goalName} is already completed.";
    }
    public override string ToString()
    {
        return $"{GetType().Name}|{_goalName}|{_description}|{_points}|{_bonusPoints}|{_totalCount}|{_completedCount}";
    }
    public void ProgressRecorded()
    {
        _completedCount++;
    }
    public bool IsGoalCompleted ()
    {
        return _completedCount >= _totalCount;
    }
}