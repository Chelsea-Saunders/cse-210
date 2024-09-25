using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> number = new List<int>();

        

        int responseNumber = -1;
        while (responseNumber != 0)
        {
            Console.Write("Enter a list of numbers, type 0 when finished: ");

            string response = Console.ReadLine();
            responseNumber = int.Parse(response);

            if (responseNumber != 0)
            {
                number.Add(responseNumber);
            }

            int sum = 0;

            foreach (int num in number)
            {
                sum += num;
            }
            Console.WriteLine($"The sum is {sum}");

            float average = ((float)sum) / number.Count;

            Console.WriteLine($"The average is {average}");

            int max = number[0];
            foreach (int num in number)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            Console.WriteLine($"The Largest number is {max}");
        }
    }
}