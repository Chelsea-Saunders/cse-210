using System;
using System.Collections.Generic;
using DesertRainSoap.Interfaces;
using DesertRainSoap.Models;
using DesertRainSoap.Handlers;
using DesertRainSoap.Data;

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

            // myRecipe.Lye = lyeInput == "2" ? LyeType.PotassiumHydroxide : LyeType.SodiumHydroxide;
            // Console.WriteLine($"Lye type chosen: {myRecipe.Lye}");

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

            // Console.WriteLine($"Lye type chosen: {myRecipe.Lye}");

            // step 3: select unit of measurement
            myRecipe.Unit = UserInputHandler.GetWeightUnit();
            Console.WriteLine($"Using {myRecipe.Unit}");

            // step 4: get total oil weight
            double totalWeight = RecipeInput.GetWeight("Total weight of oils :  ");
                            myRecipe.DesiredTotalWeight = totalWeight;
            
            // step 5: get water amount
            double waterWeight = UserInputHandler.GetWaterAmount(myRecipe);
            myRecipe.Water = waterWeight;
            Console.WriteLine($"Water: {myRecipe.FormatWeight(myRecipe.Water)}");

            // step 6: superfat percentage
            double superFat = UserInputHandler.GetSuperFatPercentage();

            // step 7: add oils
            IOilInputHandler oilInputHandler = myRecipe.Unit == WeightUnit.Percentage
                ? new PercentageOilInputHandler()
                : new WeightOilInputHandler();

            oilInputHandler.AddOils(myRecipe, totalWeight, myRecipe.Unit);

            // step 8: add additives
            var additiveInputHandler = new AdditiveHandler();
            additiveInputHandler.AddAdditive(myRecipe, totalWeight);

            // step 9: add fragrance
            var additiveHandler = new AdditiveHandler();
            additiveInputHandler.AddFragrance(myRecipe, totalWeight);

            // final recipe summary
            IRecipeFormatter recipeFormatter = new RecipeSummaryDisplay();
            recipeFormatter.DisplayRecipeSummary(myRecipe, superFat);
        }
    }
}