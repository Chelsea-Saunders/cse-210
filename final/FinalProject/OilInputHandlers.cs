
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
            while (true)
            {
                Console.WriteLine("You chose percentage-based oil input.");
                double totalPercentage = 0;

                Console.WriteLine("Available oils:");
                    foreach (var oil in SAPValues.Values.Keys)
                    {
                        Console.WriteLine(oil);
                    }

                while (totalPercentage < 100)
                {
                    Console.WriteLine("Enter oil name (or type 'done' to reset oil input):  ");
                    string oilName = Console.ReadLine()?.Trim() ?? string.Empty;

                    if ("done".Equals(oilName, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Restarting program...");
                            totalPercentage = 0;
                            recipe.ClearIngredients();
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
                if (totalPercentage == 100)
                {
                    Console.WriteLine("100% of oils added.");
                    break;
                }
            }
        }
    }
            
    public class WeightOilInputHandler : IOilInputHandler
    {
        public void AddOils(RecipeBase recipe, double totalWeight, WeightUnit unit)
        {
            Console.WriteLine($"You chose weight-based oil input of {UnitConverter.FormatWeight(totalWeight, unit)}.");
            double totalOilWeight = 0;

            foreach (var oil in SAPValues.Values.Keys)
            {
                Console.WriteLine(oil);
            }
            while (totalOilWeight < totalWeight)
            {
            // double remainingWeight = totalWeight - totalOilWeight;
            Console.WriteLine("Available oils:");
            
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
                        WeightUnit.Grams => UnitConverter.ConvertFromGrams(weight), 
                        WeightUnit.Pounds => UnitConverter.ConvertFromPounds(weight),
                        _ => weight //default to oz
                    };

                    if (weightInOunces <= remainingWeight)
                {
                    recipe.AddIngredient(new Ingredient(oilName, weightInOunces));
                    totalOilWeight += weightInOunces;

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