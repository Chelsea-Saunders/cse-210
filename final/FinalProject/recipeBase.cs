using System;
using System.Collections.Generic;
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
                
                // if (Unit == WeightUnit.Percentage)
                // {
                //     _desiredTotalWeight = value;
                // }
                // else
                // {
                //     _desiredTotalWeight = value;
                // }
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


        public override string ToString()
        {
            return $"{Name} - {_ingredients.Count} ingredients - Total Weight: {ConvertWeight(GetTotalWeight(), Unit):0.00} {Unit}";
        }
        private double ConvertWeight(double weight, WeightUnit unit)
        {
            return unit switch{
                WeightUnit.Ounces => weight,
                WeightUnit.Grams => weight * 28.3495, // 1 oz = 28.3495 g
                WeightUnit.Pounds => weight / 16.0, //16 oz = 1 lb
                WeightUnit.Percentage => throw new InvalidOperationException("Cannot directly convert percentage to weight. Handle percentage in the AddIngredient method."), // convert to %
                _ => weight,
            };
        }
        public void AddAdditive(string name, double weight)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"Please enter a name. {nameof(name)}");

            if (weight <= 0)
                throw new ArgumentOutOfRangeException(nameof(weight), "Additive must be a positive number.");

            _additives.Add(new Ingredient(name, weight));
        }
    }
}