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
            double defaultPercentage = 38.0; // default water %
            Console.WriteLine("What % of water would you like to use? (press enter for default (38%)):  ");
            string waterInput = Console.ReadLine()?.Trim();
            
            //declare water percentage variable
            double waterPercentage;

            //check for empty input
            if (!string.IsNullOrEmpty(waterInput) && double.TryParse(waterInput, out waterPercentage) && waterPercentage > 0)
            {
                double waterWeight = (waterPercentage / 100) * recipe.DesiredTotalWeight;
                recipe.Water = waterWeight;
                Console.WriteLine($"Water: {recipe.FormatWeight(recipe.Water)}");
                return waterWeight;
            }
            else
            {
                // if invalid, use default %
                Console.WriteLine($"Invalid input, using default water percentage (38%).");
                double waterWeight = (defaultPercentage / 100) * recipe.DesiredTotalWeight;
                recipe.Water = waterWeight;
                Console.WriteLine($"Water: {recipe.FormatWeight(recipe.Water)}");
                return waterWeight;
            }

        }
        public static double GetSuperFatPercentage()
        {
               // Prompt the user for superfat percentage
            Console.WriteLine("Superfat % (e.g., below 5% for harsher cleaning, 5-10% for body cleaning, 20-30% for 100% coconut oil soap): ");
            
            // Variable to hold the parsed percentage
            double superFat;

            while (true) // Keep asking until valid input is received
            {
                string input = Console.ReadLine(); // Read user input

                // Validate input: Check if it's a number between 0 and 30
                if (double.TryParse(input, out superFat) && superFat >= 0 && superFat <= 30)
                {
                    return superFat / 100; // Return as a decimal (e.g., 5% -> 0.05)
                }

                // If invalid, show an error and ask again
                Console.WriteLine("Invalid input. Please enter a number between 0 and 30.");
            }
        }
    }
}