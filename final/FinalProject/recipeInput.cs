using System;
using DesertRainSoap.Models;

namespace DesertRainSoap
{
    public class RecipeInput
    {
        public static double GetPercentage(string prompt)
        {
            double percentage;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out percentage) && percentage >= 0 && percentage <= 100)
                {
                    return percentage;
                }
                Console.WriteLine("Enter a number between 1-100");
            }
        }

        public static double GetWeight(string prompt)
        {
            double weight;
            while(true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out weight) && weight > 0)
                {
                    return weight;
                }
                Console.WriteLine("Enter a number greater than 0.");
            }
        }
    }
}