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
            double waterWeight = UserInputHandler.GetWaterAmount(myRecipe);
            myRecipe.Water = waterWeight;
            Console.WriteLine($"Water: {myRecipe.FormatWeight(myRecipe.Water)}");

            // step 6: superfat percentage
            double superFat = UserInputHandler.GetSuperFatPercentage();

            // step 7: add oils
            IOilInputHandler oilInputHandler = myRecipe.Unit == WeightUnit.Percentage
                ? new PercentageOilInputHandler()
                : new WeightOilInputHandler();

            oilInputHandler.AddOils(myRecipe, myRecipe.DesiredTotalWeight, myRecipe.Unit);

            // step 8: add fragrance
            var additiveInputHandler = new AdditiveHandler();
            additiveInputHandler.AddFragrance(myRecipe, myRecipe.DesiredTotalWeight);

            // final recipe summary
            IRecipeFormatter recipeFormatter = new RecipeSummaryDisplay();
            recipeFormatter.DisplayRecipeSummary(myRecipe, superFat, myRecipe.DesiredTotalWeight, 0);

            //save to file
            
        }
    }
}


            
            // var additiveInputHandler = new AdditiveHandler();
            // additiveInputHandler.AddAdditive(myRecipe, myRecipe.DesiredTotalWeight);