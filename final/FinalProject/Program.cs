using System;
using System.Collections.Generic;
using DesertRainSoap.Interfaces;
using DesertRainSoap.Models;
using DesertRainSoap.Handlers;
using DesertRainSoap.Data;
using System.IO.Enumeration;

namespace DesertRainSoap
{
    class Program
    {
        static void Main(string[] args)
        {   
            //step 1: create a recipe name
            Console.WriteLine("Enter the name or your recipe:  ");
            string recipeName;
            while (string.IsNullOrEmpty(recipeName = Console.ReadLine()))
            {
                Console.WriteLine("Please enter a recipe name.");
            }
            //to be able to assign lye type to this recipe
            var myRecipe = new RecipeBase($"{recipeName}");

            //step 2: choose lye type
            Console.WriteLine("Lye type: ");
            Console.WriteLine("1. Sodium Hydroxide (NaOH - default)");
            Console.WriteLine("2. Potassium Hydroxide(KOH)");
            string lyeInput = Console.ReadLine();

            if (lyeInput == "2")
            {
                myRecipe.Lye = LyeType.PotassiumHydroxide;
                Console.WriteLine("Lye type chosen: Potassium Hydroxide (KOH)");
            }
            else if (lyeInput == "1")
            {
                myRecipe.Lye = LyeType.SodiumHydroxide;
                Console.WriteLine("Lye type chosen: Sodium Hydroxide (NaOH)");
            }
            else
            {
                Console.WriteLine("Invalid input. Using default lye type: Sodium Hydroxide (NaOH)");
                myRecipe.Lye = LyeType.SodiumHydroxide;
            }

            // step 3: select unit of measurement
            myRecipe.Unit = UserInputHandler.GetWeightUnit();
            Console.WriteLine($"Using {myRecipe.Unit}");

            // step 4: get total oil weight or %
            double enteredWeight = RecipeInput.GetWeight(myRecipe.Unit == WeightUnit.Percentage
                ?"Enter the total base oil weight:  "
                : "Total weight of oils: ");

            // convert entered weight based on unit
            myRecipe.DesiredTotalWeight = myRecipe.Unit switch
            {
                WeightUnit.Percentage => enteredWeight,
                _ => enteredWeight // default to oz
            };
            Console.WriteLine($"Total oil weight: {UnitConverter.FormatWeight(myRecipe.DesiredTotalWeight, myRecipe.Unit)}");
            
            // step 5: get water amount
            UserInputHandler.GetWaterAmount(myRecipe);

            // step 6: superfat percentage
            myRecipe.Superfat = UserInputHandler.GetSuperFatPercentage();

            // step 7: add oils
            IOilInputHandler oilInputHandler ;
            if (myRecipe.Unit == WeightUnit.Percentage)
            {
                oilInputHandler = new PercentageOilInputHandler();
            }
            else 
            {
                oilInputHandler = new WeightOilInputHandler();
            }
            oilInputHandler.AddOils(myRecipe, myRecipe.DesiredTotalWeight, myRecipe.Unit);

            // step 8: add fragrance and additives
            var additiveHandler = new AdditiveHandler();
            additiveHandler.AddFragranceAndAdditives(myRecipe, myRecipe.DesiredTotalWeight);

            // final recipe summary
            IRecipeFormatter recipeFormatter = new RecipeSummaryDisplay();
            recipeFormatter.DisplayRecipeSummary(myRecipe, myRecipe.Superfat, myRecipe.DesiredTotalWeight, 0);

            //save to file
            // Prompt user to save the recipe
            Console.WriteLine("Would you like to save the recipe to a file? (yes/no): ");
            string saveResponse = Console.ReadLine()?.Trim().ToLower();

            if (saveResponse == "yes")
            {
                Console.WriteLine("Enter a file name (e.g., recipe.txt): ");
                string fileName = Console.ReadLine()?.Trim();

                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    myRecipe.SaveToFile(fileName);
                }
                else
                {
                    Console.WriteLine("Invalid file name. Recipe not saved.");
                }
            }
            else
            {
                Console.WriteLine("Recipe not saved.");
            }

        }
    }
}

//chatGPT help links:
//https://chatgpt.com/share/675b0408-e7c0-800b-913b-14a967aae689
//https://chatgpt.com/c/6751c5be-772c-800b-9302-138d6cf295a5
//https://chatgpt.com/g/g-iYSeH3EAI-website-generator/c/67525acf-80c8-800b-b7ac-7313bebc194e
//https://chatgpt.com/g/g-iYSeH3EAI-website-generator/c/6754a55b-00cc-800b-b44f-72449adfed97
//https://chatgpt.com/c/675503c8-7034-800b-b586-f9677756babb
//https://chatgpt.com/g/g-iYSeH3EAI-website-generator/c/6754e25c-bc78-800b-aaa8-481f1ad4110b
//https://chatgpt.com/g/g-iYSeH3EAI-website-generator/c/6757b85d-5728-800b-bc13-0da1dff20fc0