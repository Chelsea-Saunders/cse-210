using System;
using System.Collections.Generic;

namespace DesertRainSoap
{
    public class IngredientInfo
    {
        public string Name { get; set; }
        public string Type { get; set; } // oil or additive
        public double? SAPValue { get; set; } // only for oils
        public double?  AdditiveRate { get; set; } // only for additives

        public IngredientInfo(string name, string type, double? sapValue = null, double? additiveRate = null)
        {
            Name = name;
            Type = type;
            SAPValue = sapValue;
            AdditiveRate = additiveRate;
        }
    }
}