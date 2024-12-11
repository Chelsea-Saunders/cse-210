using System;
using DesertRainSoap.Models;
using DesertRainSoap.Data;

namespace DesertRainSoap.Handlers
{
    public class AdditiveHandler 
    {
        public void AddFragrance(RecipeBase recipe, double totalWeight)
        {
            Console.WriteLine("Would you like to add fragrance/essential oils? (yes/no):  ");
            string response = Console.ReadLine()?.Trim().ToLower();

            if (response == "yes")
            {
                //check for duplication
                if (recipe.Additives.Any(a => a.Name.Equals("Fragrance", StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Fragrance/essential oils have already been added.");
                    return;
                }

                Console.WriteLine("How many oz/lb of oils would you like to add (Check fragrance/essential oil bottle for recommended amounts in soap):  ");
                if (double.TryParse(Console.ReadLine(), out double ozPerLb) && ozPerLb > 0)
                {
                    //caclulate total frag weight
                    double totalFragranceWeight = ozPerLb * (totalWeight / 16);
                    // calculate total fragrance weight
                    recipe.AddAdditive("Fragrance", totalFragranceWeight);
                    
                    Console.WriteLine($"Added {totalFragranceWeight:0.00} oz of fragrance/essential oils (at {ozPerLb:0.00} oz/lb oils).");
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            else
            {
                Console.WriteLine("No fragrance/essential oils added.");
            }
        }
        public static double ConvertToTeaspoons(double totalOilWeight, double tspInput)
        {
            return (totalOilWeight / 16) * tspInput;
        }
    }
}   

// Things to add later:
        // public void AddAdditive(RecipeBase recipe, double totalWeight, double totalOilWeight)
        // {
        //     Console.WriteLine("Would you like to add additives? (yes/no):  ");
        //     string response = Console.ReadLine()?.Trim().ToLower();

        //     if (response == "yes")
        //     {
        //         while (true)
        //         {
        //             Console.WriteLine("Available additives:");
        //             foreach (var additive in Additive.Values.Keys)
        //             {
        //                 Console.WriteLine($"{additive} (Recommended usage: {Additive.Values[additive]} tsp/lb of oils)");
        //             }
        //             Console.WriteLine("Enter additive name (or type 'done' to finish):  ");
        //             string additiveName = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;

        //             if (additiveName.Equals("done", StringComparison.OrdinalIgnoreCase))
        //             {
        //                 break;
        //             }
        //             if (!Additive.Values.ContainsKey(additiveName))
        //             {
        //                 Console.WriteLine("Invalid additive name.");
        //                 continue;
        //             }

        //             //duplicates?
        //             if (recipe.Additives.Any(a => a.Name.Equals(additiveName, StringComparison.OrdinalIgnoreCase)))
        //             {
        //                 Console.WriteLine($"{additiveName} has already been added.");
        //                 continue;
        //             }
        //             Console.WriteLine($"How many tsp/lb of {additiveName}:  ");
        //             string tspInput = Console.ReadLine()?.Trim();
        //             bool isValidNumber = double.TryParse(tspInput, out double tspPerLb);

        //             if (isValidNumber && tspPerLb > 0)
        //             // if (double.TryParse(Console.ReadLine(), out double tspPerLb) && tspPerLb > 0)
        //             {
        //                 double additiveInTsp = AdditiveHandler.ConvertToTeaspoons(totalOilWeight, tspPerLb);
        //                 //convert total oil wieght to lbs
        //                 // double totalWeightInOunces = totalWeight;
        //                 double totalWeightInPounds = totalWeight /  16.0; // convert total weight to lbs

        //                 // calculate total additve weight in tsp
        //                 double totalAdditiveWeight = tspPerLb * totalWeightInPounds;

        //                 //round
        //                 totalAdditiveWeight = Math.Round(totalAdditiveWeight, 2);

        //                 //title case the additive name
        //                 string titleCaseAdditiveName = char.ToUpper(additiveName[0]) + additiveName.Substring(1);

        //                 // add calculated additve tsp to recipe
        //                 recipe.AddAdditive(titleCaseAdditiveName, totalAdditiveWeight);

        //                 Console.WriteLine($"Added {totalAdditiveWeight:0.00} tsp of {titleCaseAdditiveName}.");
        //             }
        //             else
        //             {
        //                 Console.WriteLine("Invalid input.");
        //             }
        //         }
        //     }
        //     else
        //     {
        //         Console.WriteLine("No additives added.");
        //     }
        // }