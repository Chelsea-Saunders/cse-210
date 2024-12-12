
using System;
using DesertRainSoap.Interfaces;
using DesertRainSoap.Models;
using DesertRainSoap.Data;

namespace DesertRainSoap.Handlers 
{
    public class PercentageOilInputHandler : BaseOilInputHandler, IOilInputHandler
    {
        public void AddOils(RecipeBase recipe, double totalWeight, WeightUnit unit)
        {
            Console.WriteLine("You chose percentage-based oil input.");
            double totalPercentage = 0;

            DisplayAvailableOils();

            while (totalPercentage < 100)
            {
                Console.WriteLine("Enter oil name (or type 'done' to reset oil input):  ");
                string oilName = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(oilName) || !IngredientsRepository.IsValidIngredient(oilName))
                {
                    Console.WriteLine("Choose from the oils listed above.");
                    DisplayAvailableOils();
                    continue;
                }

                Console.WriteLine($"Enter percentage for {oilName} (Remaining: {100 - totalPercentage}%):  ");
                if (double.TryParse(Console.ReadLine(), out double percentage) && percentage > 0 && totalPercentage + percentage <= 100)
                {
                    double oilWeight = (percentage / 100) * totalWeight;
                    recipe.AddIngredient(new Ingredient(oilName, oilWeight));
                    totalPercentage += percentage;
                    Console.WriteLine($"Added {percentage}% ({oilWeight} oz) of {oilName}.");
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }
    }
            
    public class WeightOilInputHandler : BaseOilInputHandler, IOilInputHandler
    {
        public void AddOils(RecipeBase recipe, double totalWeight, WeightUnit unit)
        {
            Console.WriteLine("You chose weight-based oil input.");
            double currentTotalWeight = 0;

            DisplayAvailableOils();

            while (currentTotalWeight < totalWeight)
            {        
                Console.WriteLine($"Enter oil name (Remaining: {totalWeight - currentTotalWeight:0.00}):  ");
                string oilName = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(oilName) || !IngredientsRepository.IsValidIngredient(oilName))
                {
                    Console.WriteLine("Choose from the oils listed above.");
                    DisplayAvailableOils();
                    continue;
                }
                Console.WriteLine($"Enter weight for {oilName}:  ");

                if (double.TryParse(Console.ReadLine(), out double weight) && weight > 0 && currentTotalWeight + weight <= totalWeight)
                {
                    recipe.AddIngredient(new Ingredient(oilName, weight));
                    currentTotalWeight += weight;
                    Console.WriteLine($"Added {weight:0.00} oz of {oilName}.");
                }
                else
                {
                    Console.WriteLine($"You cannot add more than {totalWeight - currentTotalWeight:0.00} oz of {oilName}.");
                }
            } 
        }
    }
}