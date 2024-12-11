using System;
using DesertRainSoap.Models;

namespace DesertRainSoap.Handlers
{
    public class UserInputHandler
    {
        public static WeightUnit GetWeightUnit(string input = null)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Which weight unit would you like to use: ");
                Console.WriteLine("1. Ounces (default)");
                Console.WriteLine("2. Pounds");
                Console.WriteLine("3. Grams");
                Console.WriteLine("4. Percentage (%)");
                input = Console.ReadLine();
            }

            input = input?.Trim().ToLower();
            return input switch
            {
                "1" => WeightUnit.Ounces,
                "2" => WeightUnit.Pounds,
                "3" => WeightUnit.Grams,
                "4" => WeightUnit.Percentage,
                "oz" or "ounce" or "ounces" => WeightUnit.Ounces,
                "lb" or "pound" or "pounds" => WeightUnit.Pounds,
                "g" or "gram" or "grams" => WeightUnit.Grams,
                "%" or "percent" or "percentage" => WeightUnit.Percentage,
                _ => WeightUnit.Ounces // Default to ounces
            };
        }

        public static double GetWaterAmount(RecipeBase recipe)
        {
            Console.WriteLine("What % of water would you like to use? (press enter for default (38%)):  ");
            string waterInput = Console.ReadLine()?.Trim();
            double defaultPercentage = 38.0;//default water %

            //if input is empty:
            if (string.IsNullOrEmpty(waterInput))
            {
                return (defaultPercentage / 100) * recipe.DesiredTotalWeight;
            }

            // declare waterPercentage
            double waterPercentage;
            if (double.TryParse(waterInput, out waterPercentage) && waterPercentage > 0)
            {
                return (waterPercentage / 100) * recipe.DesiredTotalWeight;
            }

            //if input = invalid, use default value
            Console.WriteLine("Invalid input. Using default water percentage (38%)");
            return (defaultPercentage / 100) * recipe.DesiredTotalWeight;
        }
        public static double GetSuperFatPercentage()
        {
            while (true)
            {
                double superFat = RecipeInput.GetPercentage(
                "Superfat % (below 5% for harsher cleaning, 5-10 for body cleaning, 20-30% for 100% coconut oil soap):  "
                );
                if (superFat > 30) 
                {
                    Console.WriteLine("Superfat percentage must be 30% or less.");
                }
                else
                {
                    return superFat / 100;
                }
            }
        }
    }
}