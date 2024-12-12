using System;
using System.Linq;
using DesertRainSoap.Data;
using DesertRainSoap.Models;

namespace DesertRainSoap
{
    public class AdditiveHandler
    {
        public void AddFragrance(RecipeBase recipe, double totalWeight)
        {
            Console.WriteLine("Would you like to add fragrance/essential oils? (yes/no): ");
            string response = Console.ReadLine()?.Trim().ToLower();

            if (response == "yes")
            {
                if (recipe.Additives.Any(a => a.Name.Equals("Fragrance", StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Fragrance/essential oils have already been added.");
                    return;
                }

                Console.WriteLine("How many oz/lb of oils would you like to add (Check fragrance bottle for recommended amounts): ");
                if (double.TryParse(Console.ReadLine(), out double ozPerLb) && ozPerLb > 0)
                {
                    double totalFragranceWeight = ozPerLb * (totalWeight / 16);
                    recipe.AddAdditive("Fragrance", totalFragranceWeight);

                    Console.WriteLine($"Added {totalFragranceWeight:0.00} oz of fragrance.");
                }
                else
                {
                    Console.WriteLine("Invalid input. No fragrance added.");
                }
            }
            else
            {
                Console.WriteLine("No fragrance/essential oils added.");
            }
        }

        // public void AddAdditives(RecipeBase recipe)
        // {
        //     Console.WriteLine("Would you like to add any other additives? (yes/no): ");
        //     string additivesResponse = Console.ReadLine()?.Trim().ToLower();

        //     if (additivesResponse == "yes")
        //     {
        //         bool addMoreAdditives = true;

        //         while (addMoreAdditives)
        //         {
        //             DisplayAvailableAdditives();

        //             Console.WriteLine("Enter the additive name: ");
        //             string additiveName = Console.ReadLine()?.Trim();
        //             if (string.IsNullOrEmpty(additiveName))
        //             {
        //                 Console.WriteLine("Enter a name from the list above.");
        //                 continue;
        //             }

        //             var additive = IngredientRepository.GetIngredient(additiveName);
        //             if (additive == null)
        //             {
        //                 Console.WriteLine("Invalid additive selected. Please choose from the list above.");
        //                 continue;
        //             }

        //             if (additive.AdditiveRate.HasValue)
        //             {
        //                 Console.WriteLine($"Recommended usage rate: {additive.AdditiveRate.Value} oz/lb.");
        //             }
        //             else
        //             {
        //                 Console.WriteLine("No recommended usage rate available.");
        //             }

        //             Console.WriteLine("How much would you like to add? ");
        //             if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
        //             {
        //                 recipe.AddAdditive(additiveName, amount);
        //                 Console.WriteLine($"Added {amount:0.00} oz of {additiveName}.");
        //             }
        //             else
        //             {
        //                 Console.WriteLine("Invalid input. Additive not added.");
        //             }

        //             Console.WriteLine("Would you like to add more additives? (yes/no): ");
        //             string addAnother = Console.ReadLine()?.Trim().ToLower();
        //             addMoreAdditives = addAnother == "yes";
        //         }
        //     }
        //     else
        //     {
        //         Console.WriteLine("No additives added.");
        //     }
        // }
        
        private void DisplayAvailableAdditives()
        {
            foreach (var additive in IngredientRepository.GetAdditives())
            {
                Console.WriteLine($"{additive.Name} (Recommended: {additive.AdditiveRate ?? 0} oz/lb)");
            }
        }
        public void AddFragranceAndAdditives(RecipeBase recipe, double totalWeight)
        {
            // Handle fragrance
            AddFragrance(recipe, totalWeight);

            // // Handle other additives
            // AddAdditives(recipe);
        }
    }
}