using System;
using DesertRainSoap.Models;
using System.Globalization;

namespace DesertRainSoap.Handlers
{
    public class RecipeSummaryDisplay : Interfaces.IRecipeFormatter 
    {
        public void DisplayRecipeSummary(RecipeBase myRecipe, double superFat, double totalOilWeight, double tspInput)
        {
            Console.WriteLine($"\nRecipe: {RecipeBase.StringUtility.ToTitleCase(myRecipe.Name)}");
            Console.WriteLine($"Total oil weight: {myRecipe.FormatWeight(myRecipe.DesiredTotalWeight)}");// total soap weight
            
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in myRecipe.Ingredients)
            {
                // if recipe unit is %, calculate and display % in oz
                if (myRecipe.Unit == WeightUnit.Percentage)
               {
                    double weightInOunces = ingredient.Weight;
                    Console.WriteLine($"- {RecipeBase.StringUtility.ToTitleCase(ingredient.Name)}: {UnitConverter.FormatWeight(weightInOunces, WeightUnit.Ounces)}");
                } 
                else
                {
                    //otherwise, display weight in selected unit
                    Console.WriteLine($"- {RecipeBase.StringUtility.ToTitleCase(ingredient.Name)}: {myRecipe.FormatWeight(ingredient.Weight)}");
                }
            }

            Console.WriteLine($"- {myRecipe.Lye}: {myRecipe.FormatWeight(myRecipe.CalculateLye(superFat))}"); // display lye type and weight
            Console.WriteLine($"- Water: {myRecipe.FormatWeight(myRecipe.Water)}");
            Console.WriteLine($"Additives (optional):");
            foreach (var additives in myRecipe.Additives)
            {
                if (additives.Name.Equals("Fragrance", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"- {RecipeBase.StringUtility.ToTitleCase(additives.Name)}: {myRecipe.FormatWeight(additives.Weight)} oz");
                }
                else
                {
                    double additiveInTsp = AdditiveHandler.ConvertToTeaspoons(totalOilWeight, tspInput);
                    Console.WriteLine($"- {RecipeBase.StringUtility.ToTitleCase(additives.Name)}: {additiveInTsp:0.00} tsp");
                }
            }
            // foreach (var additives in myRecipe.Additives)
            // {
            //     if (additives.Name.Equals("Additive", StringComparison.OrdinalIgnoreCase))
            //     {
            //         Console.WriteLine($"- {RecipeBase.StringUtility.ToTitleCase(additives.Name)}: {myRecipe.FormatWeight(additives.Amount):0.00} oz");
            //     }
            // }
        }
    }
}