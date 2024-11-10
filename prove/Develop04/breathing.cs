using System;
public class BreathingActivity: Activity
{

    //default constructor
    public BreathingActivity() : base("Breathing Exercise", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }
    public void StartBreathingActivity()
    {

        Console.WriteLine(StartMessage());

        SetActivityTime();

        int breathCycles = 0;
        int secondsToBreath = 0;

        while (true)
        {
            Console.Write("How many breathing cycles would you like to take:  ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out breathCycles) && breathCycles > 0)
            {
                break;
            }
            else
            {
                Console.Write("Please enter a valid positive number:  ");
            }
        }

        while (true)
        {
            Console.WriteLine("How many seconds would you like to breath for:  ");
            string input = Console.ReadLine();
        
            if (int.TryParse(input, out secondsToBreath) && secondsToBreath > 0)
            {
                break;
            }
            else 
            {
                Console.Write("Please enter a valid positive number");
            }
        }
        
        Console.Clear();
        Console.WriteLine("Get ready...");
        
        for (int i = 0; i < breathCycles; i++)
        {
            Console.WriteLine("Breath in...");
            Countdown(secondsToBreath);

            Console.WriteLine("Breath out...");
            Countdown(secondsToBreath);
        }
        Console.WriteLine("Well done!");
        Console.WriteLine(EndMessage());
    }
}