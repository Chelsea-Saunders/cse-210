using System;
using System.Collections.Generic;

namespace DesertRainSoap
{
    public class CalcLye
    {
        public static double CalculateLye(double totalWeight, double superFat, bool isKOH)
        {
            //base calculation for lye weight
            double lye = (totalWeight * 0.25) * (1 - superFat / 100);

            //adjust for KOH
            if (isKOH)
            {
                lye *= 1.403;
            }
            return lye;
        }
        public static double Water(double totalWeight, double waterInput)
        {
            return (waterInput / 100) * totalWeight;
        }
    }
}

//Naniniwala ko kayo!! kaya ka nga!!