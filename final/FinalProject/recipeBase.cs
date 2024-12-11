using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Enumeration;
using DesertRainSoap.Data;

namespace DesertRainSoap.Models
{
    public enum WeightUnit
    {
        Ounces, //default
        Grams, 
        Pounds, 
        Percentage
    }
    public class RecipeBase
    {
        private List<Ingredient> _ingredients = new List<Ingredient>();//oils
        private List<Ingredient> _additives = new List<Ingredient>();//additives
        private double _desiredTotalWeight;
        private LyeType _lyeType = LyeType.SodiumHydroxide; // NaOH is default lye type
        private double _water;

        public string Name { get; set; }
        public IReadOnlyList<Ingredient> Ingredients => _ingredients; //read only access to ingredients list
        public IReadOnlyCollection<Ingredient> Additives => _additives; //read only access to additives list
        public WeightUnit Unit { get; set; } = WeightUnit.Ounces; //default unit is oz
        public LyeType Lye 
        {
            get => _lyeType;
            set => _lyeType = value;
        }

        public double DesiredTotalWeight
        {
            get => _desiredTotalWeight;
            set 
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(DesiredTotalWeight), "Please enter a positive number.");
                    _desiredTotalWeight = value;
            }
        }
        public double Water
        {
            get => _water;
            set 
            {
                _water = CalcWater.ValidateWaterAmount(value, CalculateLye());
            }
        }
        //constructor
        public RecipeBase(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Please enter a name", nameof(name));
                Name = name;
            
        }
        public string GetWeightUnitName()
        {
            return Unit switch
            {
                WeightUnit.Ounces => "oz", 
                WeightUnit.Grams => "g", 
                WeightUnit.Pounds => "lbs", 
                _ => "units"
            };
        }
        public void AddIngredient(Ingredient ingredient)
        {
            if (ingredient == null)
                throw new ArgumentNullException(nameof(ingredient), "Add ingredient.");
            if (ingredient.Weight <= 0)
                throw new ArgumentOutOfRangeException(nameof(ingredient.Weight), "Enter a number greate than 0.");
            
            //check if ingredient already exists
            if (_ingredients.Any(i => i.Name.Equals(ingredient.Name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"{ingredient.Name} already exists.");
                return;
            }
            _ingredients.Add(ingredient);
        }
        public double GetTotalWeight()
        {
            double totalWeight = 0;
            foreach (var ingredient in _ingredients)
            {
                totalWeight += ingredient.Weight;
            }
            return totalWeight;
        }
        private double ConvertWeight(double weight, WeightUnit fromUnit, WeightUnit toUnit)
        {
            if (fromUnit == toUnit)
                return weight;

            double weightInOunces = fromUnit switch
            {
                WeightUnit.Ounces => weight,
                WeightUnit.Grams => weight / 28.3495, 
                WeightUnit.Pounds => weight * 16.0, 
                 _ => throw new NotSupportedException("Conversion from {fromUnit} not supported.")
            };

            return toUnit switch
            {
                WeightUnit.Ounces => weightInOunces,
                WeightUnit.Grams => weightInOunces * 28.3495,
                WeightUnit.Pounds => weightInOunces / 16.0,
                _ => throw new NotSupportedException("Conversion to {toUnit} not supported.")
            };
        }

        public void ScaleIngredientsToTotalWeight()
        {
            double currentTotalWeight = GetTotalWeight();

            if (currentTotalWeight == 0)
            {
                Console.WriteLine("Please add ingredients.");
                return;
            }

            double scaleFactor = _desiredTotalWeight / currentTotalWeight;

            foreach (var ingredient in _ingredients)
            {
                ingredient.Weight *= scaleFactor;
            }
        }
        public double CalculateLye(double superFatPercentage = 0.05)
        {
            if (superFatPercentage < 0 || superFatPercentage > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(superFatPercentage), "Superfat percentage must be between 0-100.");
            }
            double totalLye = 0;
            foreach (var ingredient in _ingredients)
            {
                if (SAPValues.Values.TryGetValue(ingredient.Name, out double sapValue))
                {
                    totalLye += ingredient.Weight * sapValue;
                }
                else
                {
                    Console.WriteLine($"Warning: No SAP value forund for {ingredient.Name}.");
                }
            }
            totalLye *= 1 - superFatPercentage;
            if (_lyeType == LyeType.PotassiumHydroxide)
            {
                totalLye *= 1.4025;
            }
            return totalLye;
        }
        public string FormatWeight(double weight)
        {
            return UnitConverter.FormatWeight(weight, Unit);
        }
        public void AddAdditive(string name, double weight)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"Please enter a name. {nameof(name)}");

            if (weight <= 0)
                throw new ArgumentOutOfRangeException(nameof(weight), "Additive must be a positive number.");

            _additives.Add(new Ingredient(name, weight));
        }
        public static class StringUtility
        {
            public static string ToTitleCase(string input)
            {
                if (string.IsNullOrEmpty(input)) return input;
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
            }
        }
        public void ClearIngredients()
        {
            _ingredients.Clear();
        }
        public override string ToString()
        {
            return $"{Name} - {_ingredients.Count} ingredients - Total Weight: {ConvertWeight(GetTotalWeight(), WeightUnit.Ounces, Unit):0.00} {Unit}";
        }

        //save to file
        public void SaveFile(string fileName, List<string> recipe)
        {
            Console.WriteLine("Would you like to save this recipe to a file? (yes/no):  ");
            string saveInput = Console.ReadLine()?.Trim().ToLower();

            if (saveInput == "yes")
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(fileName))
                    {
                        Console.WriteLine("Invalid name. File not saved. ");
                        return;
                    }
                    File.WriteAllLines(fileName, recipe);
                    Console.WriteLine($"Recipe saved to {fileName}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving file: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Recipe did not save.");
            }
        }
    }
}