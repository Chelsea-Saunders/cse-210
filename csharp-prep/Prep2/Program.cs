// using System;
// using System.Reflection.Metadata;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.Write("Enter your grade percentage: ");
//         string valueFromUser = Console.ReadLine();

//         int x = int.Parse(valueFromUser);

//         string letter = "";

//         if (x >= 90)
//         {
//             letter = "A";
//         }
//         else if (x >= 80 && x < 90)
//         {
//             letter = "B";
//         }
//         else if (x >= 70 && x < 80)
//         {
//             letter = "C";
//         }
//         else if (x >= 60 && x < 70)
//         {
//             letter = "D";
//         }
//         else if (x < 60)
//         {
//             letter = "F";
//         }

//         //stretch challange 1
//         // string sign = "";

//         // int lastDigit = (x % (10));
//         // {
//         //     if (lastDigit >= 7);
//         //     {
//         //         sign = "+";
//         //     }
//         //     else if (lastDigit < 3);
//         //     {
//         //         sign = "-";
//         //     }
//         //     else
//         //     {
//         //         sign = "";
//         //     }
//         // }
//         Console.WriteLine ($"Your grade is: {letter}");

//         if (x > 70)
//         {
//             Console.WriteLine ("Congrats, you passed!");
//         }
//         else 
//         {
//             Console.WriteLine ("Good try! Better luck next time!");
//         }
//     }
// }




using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Prep2 grades assignement");

        int number = 0;
        bool isPassing = false;

        while (!isPassing)
        {
            Console.WriteLine("What is your grade percentage:   ");
            string gpa = Console.ReadLine();
            number = int.Parse(gpa);

            if (number >= 90)
            {
                Console.WriteLine("A");
            }
            else if (number >= 80 && number < 90)
            {
                Console.WriteLine("B");
            }
            else if (number >=70 && number < 80)
            {
                Console.WriteLine("C");
            }
            else if (number >= 60 && number < 70)
            {
                Console.WriteLine("D");
            }
            else 
            {
                Console.WriteLine("F");
            }
        }
        if (number >= 70)
        {
            Console.WriteLine("Congrats, you passed the class.");
            isPassing = true; // exit loop
        }
        else 
        {
            Console.WriteLine("Nice try. Lets review and try again.");
        }
    }
}