using System;
using System.Collections.Generic;

public class GoalHandler
{
    private List<Goal> _goals = new List<Goal>();
    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }
    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created.");
            return;
        }
        Console.WriteLine("Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].DisplayGoal()}");
        }
    }
    public Goal GetGoal(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            return _goals[index];
        }
        throw new ArgumentOutOfRangeException(nameof(index), $"Invalid index: {index}. Valid range is 0 to {_goals.Count - 1}.");
    }
    public List<Goal> GetAllGoals()
    {
        return _goals;
    }
     // Calculate total points for all completed goals
    public int CalculateTotalPoints()
    {
        int totalPoints = 0;
        foreach (Goal goal in _goals)
        {
            if (goal.Completed)
            {
                totalPoints += goal.PointsReceived();
            }
        }
        return totalPoints;
    }
}