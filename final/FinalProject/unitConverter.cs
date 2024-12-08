using System;

namespace DesertRainSoap.Models
{
    public static class UnitConverter
    {
        private const double OuncesToGrams = 28.3495;
        private const double OuncesToPounds = 1.0 / 16.0;

        public static double ConvertToGrams(double ounces)
        {
            return ounces * OuncesToGrams;
        }
        public static double ConvertToPounds(double ounces)
        {
            return ounces * OuncesToPounds;
        }
        // public static double ConvertFromGrams(double grams)
        // {
        //     return grams / 28.3495;
        // }
        // public static double ConvertFromPounds(double pounds)
        // {
        //     return pounds * 16.0;
        // }
        public static string FormatWeight(double weight, WeightUnit unit)
        {
            return unit switch
            {
                WeightUnit.Ounces => $"{weight:0.00} oz", 
                WeightUnit.Grams => $"{ConvertToGrams(weight):0.00} g",
                WeightUnit.Pounds => $"{ConvertToPounds(weight):0.00} lb",
                _ => $"{weight:0.00}oz" //default to oz
            };
        }
    }
}

//Naniniwala ko kayo!! kaya ka nga!!