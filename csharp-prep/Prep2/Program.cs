using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        string valueFromUser = Console.ReadLine();

        int x = int.Parse(valueFromUser);

        string letter = "";

        if (x >= 90)
        {
            letter = "A";
        }
        else if (x >= 80 && x < 90)
        {
            letter = "B";
        }
        else if (x >= 70 && x < 80)
        {
            letter = "C";
        }
        else if (x >= 60 && x < 70)
        {
            letter = "D";
        }
        else if (x < 60)
        {
            letter = "F";
        }

        //stretch challange 1
        // string sign = "";

        // int lastDigit = (x % (10));
        // {
        //     if (lastDigit >= 7);
        //     {
        //         sign = "+";
        //     }
        //     else if (lastDigit < 3);
        //     {
        //         sign = "-";
        //     }
        //     else
        //     {
        //         sign = "";
        //     }
        // }
        Console.WriteLine ($"Your grade is: {letter}");

        if (x > 70)
        {
            Console.WriteLine ("Congrats, you passed!");
        }
        else 
        {
            Console.WriteLine ("Good try! Better luck next time!");
        }
    }
}