//oilInputHandlers.cs
using System;
using DesertRainSoap.Interfaces;
using DesertRainSoap.Models;
using DesertRainSoap.Data;

namespace DesertRainSoap.Handlers 
{
    public class PercentageOilInputHandler : IOilInputHandler
    {
        public void AddOils(RecipeBase recipe, double totalWeight, WeightUnit unit)
        {
            Console.WriteLine("You chose percentage-based oil input.");
            double totalPercentage = 0;

            while (totalPercentage < 100)
            {
                Console.WriteLine("Available oils:");
                foreach (var oil in SAPValues.Values.Keys)
                {
                    Console.WriteLine(oil);
                }
                
                Console.WriteLine("Enter oil name (or type 'done' to finish):  ");
                string oilName = Console.ReadLine()?.Trim() ?? string.Empty;

                if (oilName.Equals("done", StringComparison.OrdinalIgnoreCase))
                {
                    if (totalPercentage < 100)
                    {
                        Console.WriteLine($"You still need to add {100 - totalPercentage}% more oils.");
                        continue;
                    }
                    break;
                }
                if (!SAPValues.Values.ContainsKey(oilName))
                {
                    Console.WriteLine("Invalid oil name.");
                    continue;
                }
                Console.WriteLine($"What % of {oilName} would you like to add? (Remaining: {100 - totalPercentage}%):  ");
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
            Console.WriteLine("100% oils added. Recipe build: complete.");
        }
    }
    public class WeightOilInputHandler : IOilInputHandler
    {
        public void AddOils(RecipeBase recipe, double totalWeight, WeightUnit unit)
        {
            Console.WriteLine($"You chose weight-based oil input of {UnitConverter.FormatWeight(totalWeight, unit)}.");
            double totalOilWeight = 0;

            while (totalOilWeight < totalWeight)
            {
                // double remainingWeight = totalWeight - totalOilWeight;
                Console.WriteLine("Available oils:");
                foreach (var oil in SAPValues.Values.Keys)
                {
                    Console.WriteLine(oil);
                }

                Console.WriteLine("Enter oil name (or type 'done' to quit):  ");
                string oilName = Console.ReadLine()?.Trim() ?? string.Empty;

                if (oilName.Equals("done", StringComparison.OrdinalIgnoreCase))
                {
                    if (totalOilWeight < totalWeight)
                    {
                        double newRemainingWeight = totalWeight - totalOilWeight;
                        Console.WriteLine($"You still need to add {UnitConverter.FormatWeight(newRemainingWeight, unit)} more oils.");
                        continue;
                    }
                    break;
                }
                if (!SAPValues.Values.ContainsKey(oilName))
                {
                    Console.WriteLine("Invalid oil name.");
                    continue;
                }
                double remainingWeight = totalWeight - totalOilWeight;
                Console.WriteLine($"How much({oilName}) would you like to add? (Remaining: {UnitConverter.FormatWeight(remainingWeight, unit)}):  ");
                
                if (double.TryParse(Console.ReadLine(), out double weight) && weight > 0)
                {
                    double weightInOunces = unit switch
                    {
                        WeightUnit.Grams => UnitConverter.ConvertToGrams(weight), 
                        WeightUnit.Pounds => UnitConverter.ConvertToPounds(weight),
                        _ => weight //default to oz
                    };
                    //Debug
                    Console.WriteLine($"DEBUG: weight entered: {weight}, weight in oz: {weightInOunces}");
                    // double remainingWeight = totalWeight - totalOilWeight;

                    if (weightInOunces <= remainingWeight)
                    {
                        recipe.AddIngredient(new Ingredient(oilName, weightInOunces));
                        totalOilWeight += weightInOunces;

                        //debug
                        Console.WriteLine($"DEBUG: Weight entered: {weight}, weight in oz: {weightInOunces}");
                        Console.WriteLine($"DEBUG: Remaining weight after addition: {remainingWeight}");

                        Console.WriteLine($"Added {UnitConverter.FormatWeight(weight, unit)} of {oilName}.");
                    }
                    else
                    {
                        Console.WriteLine($"You cannot add more than {UnitConverter.FormatWeight(remainingWeight, unit)} of {oilName}.");
                    }
                }
                else 
                {
                    Console.WriteLine($"Please enter a valid weight in {unit}.");
                }
            }
            Console.WriteLine($"Recipe Build: complete.");
        }
    }
}