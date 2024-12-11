using System;
using System.Collections.Generic;

namespace DesertRainSoap
{
    public class IngredientInfo
    {
        public string Name { get; set; }
        public double? SAPValue { get; set; }
        public double?  AdditiveRate { get; set; }

        public IngredientInfo(string name, double? sapValue = null, double? additiveRate = null)
        {
            Name = name;
            SAPValue = sapValue;
            AdditiveRate = additiveRate;
        }
    }
}