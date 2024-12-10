using System;
using DesertRainSoap.Models;
using System.Globalization;

namespace DesertRainSoap.Handlers
{
    public class RecipeSummaryDisplay : Interfaces.IRecipeFormatter 
    {
        public void DisplayRecipeSummary(RecipeBase myRecipe, double superFat)
        {
            Console.WriteLine($"\nRecipe: {RecipeBase.StringUtility.ToTitleCase(myRecipe.Name)}");
            Console.WriteLine($"Total oil weight: {myRecipe.FormatWeight(myRecipe.DesiredTotalWeight)}");// total soap weight
            
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in myRecipe.Ingredients)
            {
                Console.WriteLine($"- {RecipeBase.StringUtility.ToTitleCase(ingredient.Name)}: {myRecipe.FormatWeight(ingredient.Weight)}");
            }

            Console.WriteLine($"- {myRecipe.Lye}: {myRecipe.FormatWeight(myRecipe.CalculateLye(superFat))}"); // display lye type and weight
            Console.WriteLine($"- Water: {myRecipe.FormatWeight(myRecipe.Water)}");
            Console.WriteLine($"Additives (optional):");
            foreach (var additives in myRecipe.Additives)
            {
                Console.WriteLine($"- {RecipeBase.StringUtility.ToTitleCase(additives.Name)}: {myRecipe.FormatWeight(additives.Weight)}");
            }
        }
    }
}