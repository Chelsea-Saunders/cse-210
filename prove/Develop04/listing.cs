using System;
using System.Collections.Generic;
public class ListingActivity : Activity
{
    private List<string> _randomPrompt;
    private List<string> _entries;
    private List<string> _availablePrompts;

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _randomPrompt = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _entries = new List<string>();
        _availablePrompts = new List<string>(_randomPrompt);
    }

    public void StartListingActivity()
    {
        Console.WriteLine(StartMessage());
        SetActivityTime();

        Console.Clear();
        Console.WriteLine("Get ready...");
        Spinner(3);

        if (_availablePrompts.Count == 0)
        {
            _availablePrompts = new List<string>(_randomPrompt);
        }

        Random rand = new Random();
        int randomIndex = rand.Next(_availablePrompts.Count);
        string prompt = _availablePrompts[randomIndex];
        _availablePrompts.RemoveAt(randomIndex);

        Console.WriteLine("Consider the following question:  ");
        Countdown(5);
        Console.WriteLine(prompt);
        Console.WriteLine("List as many responses as you can. Press Enter after each one.");

        Spinner(5);

        DateTime endTime = DateTime.Now.AddSeconds(_setActivityTime);
        while (DateTime.Now < endTime)
        {
            Console.Write("Enter a response: ");
            string response = Console.ReadLine();
            if (!string.IsNullOrEmpty(response))
            {
                _entries.Add(response);
            }
        }
        Console.WriteLine($"\nYou made {_entries.Count} entries.");
        // foreach (string entry in _entries)
        // {
        //     Console.WriteLine("- " + entry);
        // }
        Console.WriteLine("Well done!");
        Console.WriteLine(EndMessage());
    }
}














// using System;
// using System.Diagnostics;
// using System.Threading;
// public class RunListingActivity
// {
//     public static void startListingActivity()
//     {
//         string[] randomPrompt = new string[]
//         {
//             "Who are people that you appreciate?",
//             "What are personal strengths of yours?",
//             "Who are people that you have helped this week?",
//             "When have you felt the Holy Ghost this month?",
//             "Who are some of your personal heroes?",
//         };
//         Random rand = new Random();
//         int randomIndex = rand.Next(randomPrompt.Length);
//         string selectedPrompt = randomPrompt[randomIndex];

//         int duration = Activity.ActivityDuration();

//         Console.WriteLine(selectedPrompt); // random prompt

//         Console.WriteLine("Take a few minutes to think about this question...");
//         Activity.Spinner(5);

//         Console.WriteLine("Now, start typing your answers. Press Enter after each one and keep typing until time runs out.");

//         List <string> responses = new List<string>();
//         Stopwatch timer = Stopwatch.StartNew(); // start timer

//         while (timer.Elapsed.TotalSeconds < duration)
//         {
//             string response = Console.ReadLine();
//             if (!string.IsNullOrEmpty(response))
//             {
//                 responses.Add(response);
//             }
//         }
//         Console.WriteLine($"Awesome list of {responses.Count} things.");
//         Activity.ClosingMessage();
//     }
// }