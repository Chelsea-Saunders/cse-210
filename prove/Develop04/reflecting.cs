using System;
using System.Collections.Generic;
public class ReflectingActivity : Activity
{
    private List<string> _randomPrompt;
    private List<string> _reflectionPrompt;
    private List<string> _availablePrompts;

    public ReflectingActivity() : base("Reflect Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _randomPrompt = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Think of a time when you felt God leading you to do something for someone else.", 
            "Think of a time when you felt God's approval for you."
        };

        _reflectionPrompt = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
            "What made you want to do this in the first place?",
            "If you could do it again, what would you do differently?",
            "Do you feel like this experience has changed you?",
            "How has this experience helped you grow into the person you are today?"
        };

        _availablePrompts = new List<string>(_randomPrompt);
    }

        public void StartReflectingActivity()
    {
        Console.WriteLine(StartMessage());
        SetActivityTime();

        Console.Clear();
        Console.WriteLine("Get ready...");
        Spinner(2);

        Random rand = new Random();

        if (_availablePrompts.Count == 0)
        {
            _availablePrompts = new List<string>(_randomPrompt);
        }

        int randomIndex = rand.Next(_availablePrompts.Count);
        string mainPrompt = _availablePrompts[randomIndex];
        _availablePrompts.RemoveAt(randomIndex);

        Console.WriteLine("Reflect on these questons and how they relate to your experience:  ");
        Spinner(3);
        Console.WriteLine(mainPrompt);
        Spinner(5);

        DateTime endTime = DateTime.Now.AddSeconds(_setActivityTime);
        int reflectionIndex = 0;

        while (DateTime.Now < endTime)
        {
            Console.WriteLine(_reflectionPrompt[reflectionIndex]);
            Spinner(5);

            reflectionIndex = (reflectionIndex + 1) % _reflectionPrompt.Count;
        }
        Console.WriteLine("Well done!");
        Console.WriteLine(EndMessage());
    }
}