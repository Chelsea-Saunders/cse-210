
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
            while (true)
            {
                Console.WriteLine($"You chose weight-based oil input of {UnitConverter.FormatWeight(totalWeight, unit)}.");
                double totalOilWeight = 0;

                Console.WriteLine("Available oils:");
                foreach (var oil in SAPValues.Values.Keys)
                {
                    Console.WriteLine(oil);
                }
                while (totalOilWeight < totalWeight)
                {            
                    Console.WriteLine("Enter oil name (or type 'done' to quit):  ");
                    string oilName = Console.ReadLine()?.Trim() ?? string.Empty;

                    if (oilName.Equals("done", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Clear();
                        Console.WriteLine("Resetting oil input...");
                        totalOilWeight = 0;
                        recipe.ClearIngredients();
                        break;
                    }

                    if (!SAPValues.Values.ContainsKey(oilName))
                    {
                        Console.WriteLine("Invalid oil name.");
                        continue;
                    }
                    double remainingWeight = totalWeight - totalOilWeight;

                    if (unit == WeightUnit.Percentage)
                    {
                        Console.WriteLine($"What percentage of {oilName} would you like to add? (Remaining: {100 - totalOilWeight}%):  ");

                        if (double.TryParse(Console.ReadLine(), out double percentage) && percentage > 0 && totalOilWeight + percentage <= 100)
                        {
                            double weightInOunces = (percentage / 100) * recipe.DesiredTotalWeight;
                            recipe.AddIngredient(new Ingredient(oilName, weightInOunces));
                            totalOilWeight += percentage;//increment by % not weight
                            Console.WriteLine($"Added {percentage}% ({UnitConverter.FormatWeight(weightInOunces, WeightUnit.Ounces)} of {oilName})");
                        }
                        else
                        {
                            Console.WriteLine("Input can't exceed remainint total.");
                        }
                    }
                    else
                    {
                        //handle weight based input
                        Console.WriteLine($"How much ({oilName}) would you like to add? (Remaining: {UnitConverter.FormatWeight(remainingWeight, unit)}):  ");

                        if (double.TryParse(Console.ReadLine(), out double weight) && weight > 0)
                        {
                            if (weight <= remainingWeight)
                            {
                                recipe.AddIngredient(new Ingredient(oilName, weight));
                                totalOilWeight += weight;
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
                }
                if (totalOilWeight == totalWeight || totalOilWeight >= totalWeight)
                {
                    Console.WriteLine($"oil input: complete.");
                    break;
                }
            } 
        }
    }
}