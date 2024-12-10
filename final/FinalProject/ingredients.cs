using System;
using System.Collections.Generic;

namespace DesertRainSoap.Models
{
    public class Ingredient
    {
        public string Name { get; set; }
        public double Weight { get; set; } // weight in grams, oz, etc...

        public Ingredient(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{Name} - {Weight}";
        }
    }
}