using System;
using DesertRainSoap.Models;

namespace DesertRainSoap.Handlers
{
    public class RecipeSummaryDisplay : Interfaces.IRecipeFormatter 
    {
        public void DisplayRecipeSummary(RecipeBase myRecipe, double superFat)
        {
            Console.WriteLine($"\nRecipe: {myRecipe.Name}");
            Console.WriteLine($"{myRecipe.Lye}: {myRecipe.FormatWeight(myRecipe.CalculateLye(superFat))}"); // display lye type and weight
            Console.WriteLine($"Total Soap Weight: {myRecipe.FormatWeight(myRecipe.DesiredTotalWeight)}");// total soap weight
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in myRecipe.Ingredients)
            {
                Console.WriteLine($"- {ingredient.Name}: {myRecipe.FormatWeight(ingredient.Weight)}");
            }
            Console.WriteLine($"Water: {myRecipe.FormatWeight(myRecipe.Water)}");
        }
    }
}

//Naniniwala ko kayo!! kaya ka nga!!