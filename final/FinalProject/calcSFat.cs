using System;
using System.Collections.Generic;

namespace DesertRainSoap
{
    public class calcSFat
    {
        public static double ApplySuperFat(double totalLye, double superFatPercentage)
        {
            if (superFatPercentage < 0 || superFatPercentage > 100)
            {
                throw new ArgumentOutOfRangeException("Superfat percentage must be between 0-100.");
            }
            return totalLye * (1 - superFatPercentage);
        }
    }
}