using System;
using DesertRainSoap.Models;
using DesertRainSoap.Data;

namespace DesertRainSoap.Handlers
{
    public class AdditiveHandler 
    {
        public void AddFragrance(RecipeBase recipe, double totalWeight)
        {
            // step 1: ask if want frag
            Console.WriteLine("Would you like to add fragrance/essential oils? (yes/no):  ");
            string response = Console.ReadLine()?.Trim();

            if (response == "yes")
            {
                //check for duplication
                if (recipe.Additives.Any(a => a.Name.Equals("Fragrance", StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Fragrance/essential oils have already been added.");
                    return;
                }
                else
                {
                    Console.WriteLine("How many oz/lb of oils would you like to add (Check fragrance/essential oil bottle for recommended amounts in soap):  ");
                    if (double.TryParse(Console.ReadLine(), out double ozPerLb) && ozPerLb > 0)
                    {
                        //caclulate total frag weight
                        double totalFragranceWeight = ozPerLb * (totalWeight / 16);
                        recipe.AddAdditive("Fragrance", totalFragranceWeight);
                        
                        Console.WriteLine($"Added {totalFragranceWeight:0.00} oz of fragrance/essential oils (at {ozPerLb:0.00} oz/lb oils).");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }
            }
            else
            {
                Console.WriteLine("No fragrance/essential oils added.");
            }  
        }
        // public void AddAdditives(string name, double weight)
        // {
        //     // step 2 ask about other additives
        //     Console.WriteLine("Would you like to add any other additives? (yes/no):  ");
        //     string additivesResponse = Console.ReadLine()?.Trim().ToLower();    

        //     if (additivesResponse == "yes")
        //     {
        //         bool addMoreAdditives = true;

        //         while (addMoreAdditives)
        //         {
        //             //show additives
        //             DisplayAvailableAdditives();

        //             //ask for additive name
        //             Console.WriteLine("Enter the additive name:  ");
        //             string additiveName = Console.ReadLine()?.Trim();
        //             if (string.IsNullOrEmpty(additiveName))
        //             {
        //                 Console.WriteLine("Enter a name from the list above.");
        //                 continue;
        //             }
        //             //get additive
        //             var additive = IngredientRepository.GetIngredient(additiveName);
        //             if (additive == null)
        //             {
        //                 Console.WriteLine("Choose additive from list above.");
        //                 continue;
        //             }

        //             //display usage rate
        //             if (additive.AdditiveRate.HasValue)
        //             {
        //                 Console.WriteLine($"Recommended usage rate: {additive.AdditiveRate} oz/lb.");
        //             }
        //             else 
        //             {
        //                 Console.WriteLine("No recommended usage rate available.");
        //             }

        //             //ask for amount to add
        //             Console.WriteLine("How much would you like to add?  ");
        //             if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
        //             {
        //                 recipe.AddAdditive(additiveName, amount);
        //                 Console.WriteLine($"Added {amount:0.00} oz of {additiveName}.");
        //             }
        //             else
        //             {
        //                 Console.WriteLine("Invalid input. Additive not added.");
        //             }
        //             //ask if adding more additives
        //             Console.WriteLine("Would you like to add more additives? (yes/no):  ");
        //             string addAnother = Console.ReadLine()?.Trim().ToLower();
        //             addMoreAdditives = addAnother == "yes";
        //         }
        //     }
        //     else
        //     {
        //         Console.WriteLine("No additives added.");
        //     }
        // }
            
        public void DisplayAvailableAdditives()
        {
            // Console.WriteLine("Available additives:");
            foreach (var additive in IngredientsRepository.GetAdditives())
            {
                Console.WriteLine($"{additive.Name} (Recommended: {additive.UsageRate ?? 0} oz/lb)");
            }
        }
        public static double ConvertToTeaspoons(double totalOilWeight, double tspInput)
        {
            return (totalOilWeight / 16) * tspInput;
        }
    }
}   