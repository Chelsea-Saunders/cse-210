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
    public enum LyeType
    {
        SodiumHydroxide, // NaOH - default
        PotassiumHydroxide // KOH - liquid soap
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
        public double Superfat { get; set; } //property to store superfat percentage
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
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Enter a positive number.");
                };
                //warning needs more water
                if (value < CalculateLye())
                {
                    Console.WriteLine("WARNING: Not enough water for lye. Increase water amount.");
                }
                _water = value;
            }
        }
        public class BaseIngredient
        {
            public string Name { get; set; }
            public double Weight { get; set; }

            public BaseIngredient(string name, double weight)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException(nameof(name), "Please enter a name.");
                }
                if (weight <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(weight), "Please enter a positive number.");
                }
                Name = name;
                Weight = weight;
            }
        }
        //constructor
        public RecipeBase(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Please enter a name", nameof(name));
                Name = name;
                _water = CalculateWater(38.0);
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
                var ingredientData = IngredientsRepository.Ingredients.FirstOrDefault(i => i.Name.Equals(ingredient.Name, StringComparison.OrdinalIgnoreCase));

                if (ingredientData?.SAPValue != null)
                {
                    totalLye += ingredient.Weight * (double)ingredientData.SAPValue;
                }
                else
                {
                    Console.WriteLine($"SAP value not found for {ingredient.Name}");
                }
            }

            totalLye *= 1 - superFatPercentage / 100;
            if (_lyeType == LyeType.PotassiumHydroxide)
            {
                totalLye *= 1.4025;
            }
            return totalLye;
            }

        public double CalculateWater(double waterPercentage)
        {
            if (waterPercentage <= 0 || waterPercentage > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(waterPercentage), "Water percentage must be between 0-100.");
            }
            return waterPercentage / 100 * _desiredTotalWeight;
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
        public void SaveToFile(string fileName)
        {
            List<string> lines = new List<string>
            {
                $"Recipe Name: {Name}",
                $"Lye Type: {Lye}",
                $"Total Oil Weight: {FormatWeight(DesiredTotalWeight)}",
                $"Water: {FormatWeight(Water)}",
                $"Superfat: {Superfat * 100}%",
                "Oils:"
            };
            //add ingredients to file
            lines.AddRange(Ingredients.Select(i => $"- {i.Name}: {FormatWeight(i.Weight)}"));

            //add addtives to file
            if (Additives.Any())
            {
                lines.Add("Additives: ");
                lines.AddRange(Additives.Select(a => $"- {a.Name}: {FormatWeight(a.Weight)}"));
            }
            //write/save to file
            try
            {
                File.WriteAllLines(fileName, lines);
                Console.WriteLine($"Recipe saved to {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving recipe to {fileName}: {ex.Message}");
            }
        }
    }
}