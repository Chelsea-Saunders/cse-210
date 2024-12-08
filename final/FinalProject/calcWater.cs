using System;
using System.Collections.Generic;

namespace DesertRainSoap
{
    public static class CalcWater 
    {
        public static double CalculateDefaultWater(double totalWeight, double defaultPercentage = 0.38)
        {
            if (totalWeight <= 0)
            {
                Console.WriteLine("TOTAL WEIGHT MUST BE GREATER THAN 0!");
            }
            return totalWeight * defaultPercentage;
        }
        public static double ValidateWaterAmount(double waterAmount, double lyeAmount)
        {
            if (waterAmount < lyeAmount)
            {
                Console.WriteLine("WARNING: WATER AMOUNT IS LESS THAN LYE AMOUNT!");
                return lyeAmount;
            }
            else
            {
                return waterAmount;
            }
        }
    }
}

//Naniniwala ko kayo!! kaya ka nga!!