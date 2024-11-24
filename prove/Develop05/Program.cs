using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;

public class Program
{
    //store goals
    public static List<Goal> goalsList = new List<Goal>();
    public static int points = 0;
    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            // Console.WriteLine("Hello Develop05 World!");
            Console.WriteLine();
            //opening points message
            Console.WriteLine($"You have {points} points.");
            //main menu
            Console.WriteLine($"Menu Options:");
            Console.WriteLine($"   1. Create New Goal");
            Console.WriteLine($"   2. List Goals");
            Console.WriteLine($"   3. Save Goals");
            Console.WriteLine($"   4. Load Goals");
            Console.WriteLine($"   5. Record Event");
            Console.WriteLine($"   6. Exit");
            Console.WriteLine("Select a choice from the menu:  ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1": 
                    CreateNewGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Exiting Eternal Quest Program. Goodbye!");
                    exit = true;
                    break;
                default:
                    // Console.Clear();
                    Console.WriteLine("Invalid choice, please choose a number between 1-6:  \n");
                    continue;
            }
        }
    }
    static void CreateNewGoal()
    {
        Console.WriteLine("Goal Types");
        Console.WriteLine("   1.Simple Goal");
        Console.WriteLine("   2.Eternal Goal");
        Console.WriteLine("   3.Checklist Goal");
        Console.WriteLine("What type of goal would you like to create:  ");

        string newGoal = Console.ReadLine();

        Goal goal = null;
        switch (newGoal)
        {
            case "1":
                goal = SimpleGoal();
                break;
            case "2":
                goal = EternalGoal();
                break;
            case "3":
                goal = CreateChecklistGoal();
                break;
            default:
                Console.WriteLine("Invalid input. Please enter a number 1-3");
                return;
        }
        if (goal != null)
        {
            goalsList.Add(goal);
            Console.WriteLine("Goal Created");
        }
    }
    static Goal SimpleGoal()
    {
        Console.WriteLine("What is the name of your new simple goal?  \n");
        string name = Console.ReadLine();

        Console.Write("Type a short description of it:  \n");
        string description = Console.ReadLine();

        int points;
        while (true)
        {
            Console.Write("How many points do you want to earn from completing this goal?  \n");
            
            if (int.TryParse(Console.ReadLine(), out points) && points > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter a positive number.");
            }
        }

        return new SimpleGoal(name, description, points);
    }
    static Goal EternalGoal()
    {
        Console.WriteLine("What is the name of your new eternal goal?  ");
        string name = Console.ReadLine();

        Console.Write("Type a short description of it:  \n");
        string description = Console.ReadLine();
        int points;
        while (true)
        {
            Console.Write("How many points do you do you want to count towards this goal every time you do it? \n");
            
            if (int.TryParse(Console.ReadLine(), out points) && points > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter a positive number.");
            }
        }
        // Console.Write("How many points do you do you want to count towards this goal every time you do it?  \n");
        // int points = int.Parse(Console.ReadLine());

        return new EternalGoal(name, description, points);
    }
    static Goal CreateChecklistGoal() 
    {
        Console.WriteLine("What is the name of your new checklist goal");
        string name = Console.ReadLine();

        Console.Write("Type a short description of it:  \n");
        string description = Console.ReadLine();

        int points;
        while (true)
        {
            Console.Write("How many points do you want to earn each time you do this goal:  \n");
            
            if (int.TryParse(Console.ReadLine(), out points) && points > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter a positive number.");
            }
        }
        int count;
        while (true)
        {
            Console.Write("How many times do you want to complete this goal?  \n");
            if (int.TryParse(Console.ReadLine(), out count) && count > 0)
            {
                break;
            }
            else 
            {
                Console.WriteLine("Please enter a positive number.");
            }
        }
        int bonusPoints;
        while (true)
        {
            Console.Write("How many bonus points do you want for completing this goal?  \n");
            if (int.TryParse(Console.ReadLine(), out bonusPoints) && bonusPoints >0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter a positive number.");
            }
        }
        return new ChecklistGoal(name, description, points, bonusPoints, count);   
    }
    static void ListGoals()
    {
        Console.WriteLine("\nYour Goals:  ");
        if (goalsList.Count == 0)
        {
            Console.WriteLine("No goals created.");
        }
        for(int i = 0; i < goalsList.Count; i++)
        {
            Console.WriteLine($"{i +1}. {goalsList[i].DisplayGoal()}");
        }
        
    }
    static void SaveGoals()
    {
        Console.WriteLine("Enter the name of the file you would like your file saved to:  ");
        string fileName = Console.ReadLine();

        List<string> goalData = new List<string>();
        foreach (Goal goal in goalsList)
        {
            string serializedGoal = goal.ToString();
            // Console.WriteLine($"DEBUG: Saving goal data: {serializedGoal}");
            goalData.Add(serializedGoal);
        }

        File.WriteAllLines(fileName, goalData);
        Console.WriteLine($"Goals saved to {fileName}.");
    }

    static void LoadGoals()
    {
        Console.WriteLine("Input the file name:  ");
        string fileName = Console.ReadLine();
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found. Please enter the correct file name.");
            return;
        }
        goalsList.Clear();
        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|'); 
            string goalType = parts[0]; //type of goal
            string goalName = parts[1]; // name of goal
            string description = parts[2]; //decription of goal

            if (goalType == "SimpleGoal")
            {
                int points = int.Parse(parts[3]);
                bool completed = parts[4] == "1";
                goalsList.Add(new SimpleGoal(goalName, description, points) {Completed = completed});
            }
            else if (goalType == "ChecklistGoal")
            {
                int checklistPoints = int.Parse(parts[3]);
                int bonusPoints = int.Parse(parts[4]);
                int totalCount = int.Parse(parts[5]);
                int completedCount = int.Parse(parts[6]);

                ChecklistGoal checklistGoal = new ChecklistGoal(goalName, description, checklistPoints, bonusPoints, totalCount);

                for (int i = 0; i < completedCount; i++)
                {
                    checklistGoal.ProgressRecorded();
                }
                goalsList.Add(checklistGoal);
            }
            else if (goalType == "EternalGoal")
            {
                int points = int.Parse(parts[3]);
                goalsList.Add(new EternalGoal(goalName, description, points));
            }
        }
    }
    static void RecordEvent()
    {
        if (goalsList.Count == 0)
        {
            Console.WriteLine("No goal recorded.");
            return;
        }

        Console.WriteLine("\nWhich goal would you like to record?");
        for (int i = 0; i < goalsList.Count; i ++)
        {
            Console.WriteLine($"{i + 1}. {goalsList[i].DisplayGoal()}");
        }
        Console.WriteLine("Enter the number of the goal:  ");
        if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex > 0 && goalIndex <= goalsList.Count)
        {
            Goal selectedGoal = goalsList[goalIndex - 1];
            string result = selectedGoal.RecordEvent();
            Console.WriteLine(result);

            int eventPoints = selectedGoal.PointsReceived();
            points += eventPoints;

            Console.WriteLine($"\nYou have {points} points.");
        }
        else
        {
            Console.WriteLine("Invalid input. Returning to menu.");
        }
    }
    public static bool AllGoalsCompleted(List<Goal> goals)
{
    foreach (Goal goal in goals)
    {
        // Check if it's a SimpleGoal or ChecklistGoal and if it's not completed
        if ((goal is SimpleGoal || goal is ChecklistGoal) && !goal.Completed)
        {
            return false; // If any goal is not completed, return false
        }
    }
    return true; // All SimpleGoal and ChecklistGoal are completed
}
}