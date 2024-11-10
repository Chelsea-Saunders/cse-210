using System;

public class Activity
{
    private string _activityName;
    private string _activityDescription;
    protected int _setActivityTime;

    //constructor
    public Activity(string activityName, string activityDescription)
    {
        _activityName = activityName;
        _activityDescription = activityDescription;
    }
    public string StartMessage()
    {
        return $"Welcome to the Mindfullness App! You've chosen the {_activityName}. \n{_activityDescription}";
    }
    public void Spinner(int seconds)
    {
        string[] spinner = new string[] {"/", "-", "\\", "|"}; // array to hold spinning characters
        int index = 0; // index to track current character
        int totalSpins = seconds * 5; // calculate total spins based on seconds entered

        for (int i = 0; i < totalSpins; i++) // loop through number of seconds
        {
            Console.Write(spinner[index]); // show current character on console
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop); // move cursor back one space to overwrite current character
            index = (index + 1) % spinner.Length; // add 1 to index and w/ remainder of length, loop back 
            Thread.Sleep(250); // pause for 1/4 second
        }
        Console.WriteLine(" "); //\b \b
    }
    public void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--) 
        {
            Console.Write(i);
            Console.Out.Flush(); // flushed the output buffer to show the countdown
            Thread.Sleep(1000); // pause for 1 second
            Console.Write("\r  \r"); // clears previous lines for cleaner code
        }
    }
    public void SetActivityTime()
    {
        bool validInput = false;

        while (!validInput)
        {
            Console.WriteLine("In seconds, how long would you like to do this activity for?");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int seconds) && seconds > 0)
            {
                _setActivityTime = seconds;
                validInput = true;
            }
            else
            {
                Console.WriteLine("Please enter a valid positive number.");
            }
        }
    }
    public string EndMessage()
    {
        Spinner(3);
        return$"You have completed {_setActivityTime} seconds of {_activityName}.";
    }
}


 // ChatGPT: https://chatgpt.com/share/672e6781-d5bc-800b-899e-019013fbf899