using System;
using System.Collections.Generic;
using System.Linq;

namespace DesertRainSoap.Data
{
    public static class IngredientsRepository
    {
        public static readonly List<IngredientData> Ingredients = new List<IngredientData>
        {
            new IngredientData{ Name = "Almond Butter", SAPValue = 0.134, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Almond Oil", SAPValue = 0.135, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Aloe Butter", SAPValue = 0.171, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Apricot Kernel Oil", SAPValue = 0.135, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Argan Oil", SAPValue = 0.135, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Avocado Butter", SAPValue = 0.133, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Avocado Oil", SAPValue = 0.133, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Babassu Oil", SAPValue = 0.176, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Beeswax", SAPValue = 0.067, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Borage Oil", SAPValue = 0.135, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Canola Oil", SAPValue = 0.133, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Castor Oil", SAPValue = 0.128, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Cocoa Butter", SAPValue = 0.138, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Coconut Oil", SAPValue = 0.183, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Coconut Oil, Fractionated", SAPValue = 0.232, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Coffee Bean Oil, Roasted", SAPValue = 0.128, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Corn Oil", SAPValue = 0.137, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Cottonseed Oil", SAPValue = 0.138, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Cranberry Seed Oil", SAPValue = 0.135, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Cucumber Seed Oil", SAPValue = 0.133, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Cupuacu Butter", SAPValue = 0.137, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Emu Oil", SAPValue = 0.135, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Evening Primrose Oil", SAPValue = 0.135, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Flax Oil", SAPValue = 0.135, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Ghee", SAPValue = 0.162, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Goose Fat", SAPValue = 0.137, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Grapeseed Oil", SAPValue = 0.137, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Hazelnut Oil", SAPValue = 0.139, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Hemp Oil", SAPValue = 0.138, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Illipe Butter", SAPValue = 0.137, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Jojoba Oil", SAPValue = 0.066, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Karanja Oil", SAPValue = 0.132, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Kokum Butter", SAPValue = 0.135, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Kpangnan Butter", SAPValue = 0.135, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Kukui Nut Oil", SAPValue = 0.135, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Lanolin", SAPValue = 0.076, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Lard", SAPValue = 0.141, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Laurel Fruit Oil", SAPValue = 0.141, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Lauric Acid", SAPValue = 0.200, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Linseed Oil", SAPValue = 0.135, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Loofa Seed Oil", SAPValue = 0.133, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Macadamia Nut Butter", SAPValue = 0.134, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Macadamia Nut Oil", SAPValue = 0.139, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Mango Seed Butter", SAPValue = 0.136, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Mango Seed Oil", SAPValue = 0.135, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Marula Oil", SAPValue = 0.137, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Meadowfoam Oil", SAPValue = 0.120, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Milk", SAPValue = 0.162, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Mink Oil", SAPValue = 0.140, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Moringa Oil", SAPValue = 0.182, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Mowrah Butter", SAPValue = 0.137, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Murumuru Butter", SAPValue = 0.138, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Mustard Oil", SAPValue = 0.123, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Myristic Acid", SAPValue = 0.200, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Neem Tree Oil", SAPValue = 0.138, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Oat Oil", SAPValue = 0.135, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Oleic Acid", SAPValue = 0.144, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Olive Oil", SAPValue = 0.135, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Olive Oil Pomace", SAPValue = 0.134, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Palm Kernel Oil", SAPValue = 0.178, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Palm Kernel Oil Flakes", SAPValue = 0.178, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Palm Oil", SAPValue = 0.142, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Papaya Seed Oil", SAPValue = 0.113, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Passion Fruit Seed Oil", SAPValue = 0.130, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Peach Kernel Oil", SAPValue = 0.135, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Peanut Oil", SAPValue = 0.137, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Pistachio Oil", SAPValue = 0.133, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Plum Kernel Oil", SAPValue = 0.135, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Pomegranate Seed Oil", SAPValue = 0.135, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Poppy Seed Oil", SAPValue = 0.138, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Pumpkin Seed Oil (Virgin)", SAPValue = 0.139, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Rabbit Fat", SAPValue = 0.143, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Rapeseed Oil", SAPValue = 0.125, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Red Palm Butter", SAPValue = 0.142, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Rice Bran Oil", SAPValue = 0.133, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Rosehip Oil", SAPValue = 0.133, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Safflower Oil", SAPValue = 0.137, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Safflower Oil (High Oleic)", SAPValue = 0.137, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Sal Butter", SAPValue = 0.132, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Saw Palmetto Extract", SAPValue = 0.164, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Saw Palmetto Oil", SAPValue = 0.157, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Sea Buckthorn Oil (Seed)", SAPValue = 0.139, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Sea Buckthorn Oil (Seed and Berry)", SAPValue = 0.139, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Sesame Oil", SAPValue = 0.134, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Shea Butter", SAPValue = 0.128, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Shea Oil", SAPValue = 0.132, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Soybean Oil", SAPValue = 0.136, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Soybean (27.5% Hydrogenated)", SAPValue = 0.137, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Stearic Acid", SAPValue = 0.153, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Sunflower Oil", SAPValue = 0.135, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Sunflower Oil (High Oleic)", SAPValue = 0.135, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Tallow", SAPValue = 0.143, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Tucuma Seed Butter", SAPValue = 0.170, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Walnut Oil", SAPValue = 0.135, Type = "Oil", UsageRate = null},
            new IngredientData{ Name = "Wheat Germ Oil", SAPValue = 0.130, Type = "Oil", UsageRate = null},

            new IngredientData{ Name = "Activated Charcoal", SAPValue = null, Type = "Additive", UsageRate = 1.0},
            new IngredientData{ Name = "Aloe Vera", SAPValue = null, Type = "Additive", UsageRate = 0.5},
            new IngredientData{ Name = "Bentonite Clay", SAPValue = null, Type = "Additive", UsageRate = 1.0},
            new IngredientData{ Name = "Calendula Petals", SAPValue = null, Type = "Additive", UsageRate = 1.0},
            new IngredientData{ Name = "Chamomile", SAPValue = null, Type = "Additive", UsageRate = 3.0},
            new IngredientData{ Name = "Cocoa Powder", SAPValue = null, Type = "Additive", UsageRate = 1.0},
            new IngredientData{ Name = "Coffee Grounds", SAPValue = null, Type = "Additive", UsageRate = 2.5},
            new IngredientData{ Name = "Colloidal Oatmeal", SAPValue = null, Type = "Additive", UsageRate = 2.5},
            new IngredientData{ Name = "Dead Sea Mud", SAPValue = null, Type = "Additive", UsageRate = 1.0},
            new IngredientData{ Name = "French Green Clay", SAPValue = null, Type = "Additive", UsageRate = 1.0},
            new IngredientData{ Name = "Goat Milk Powder", SAPValue = null, Type = "Additive", UsageRate = 2.5},
            new IngredientData{ Name = "Honey", SAPValue = null, Type = "Additive", UsageRate = 2.5},
            new IngredientData{ Name = "Kaolin Clay", SAPValue = null, Type = "Additive", UsageRate = 1.0},
            new IngredientData{ Name = "Lavender Buds", SAPValue = null, Type = "Additive", UsageRate = 1.0},
            new IngredientData{ Name = "Madder Root", SAPValue = null, Type = "Additive", UsageRate = 1.0},
            new IngredientData{ Name = "Milk Powder", SAPValue = null, Type = "Additive", UsageRate = 2.5},
            new IngredientData{ Name = "Neem Powder", SAPValue = null, Type = "Additive", UsageRate = 2.0},
            new IngredientData{ Name = "Paprika", SAPValue = null, Type = "Additive", UsageRate = 2.5},
            new IngredientData{ Name = "Rose Clay", SAPValue = null, Type = "Additive", UsageRate = 1.0},
            new IngredientData{ Name = "Rose Petals", SAPValue = null, Type = "Additive", UsageRate = 1.0},
            new IngredientData{ Name = "Sea Salt", SAPValue = null, Type = "Additive", UsageRate = 1.0},
            new IngredientData{ Name = "Spirulina Powder", SAPValue = null, Type = "Additive", UsageRate = 2.5},
            new IngredientData{ Name = "Titanium Dioxide", SAPValue = null, Type = "Additive", UsageRate = 1.0},
            new IngredientData{ Name = "Turmeric", SAPValue = null, Type = "Additive", UsageRate = 2.5},
            new IngredientData{ Name = "Wheatgrass Powder", SAPValue = null, Type = "Additive", UsageRate = 2.5},
            new IngredientData{ Name = "Zinc Oxide", SAPValue = null, Type = "Additive", UsageRate = 1.0}
        };

        public static IEnumerable<IngredientData> GetOils()
        {
            return Ingredients.Where(i => i.Type.Equals("Oil", StringComparison.OrdinalIgnoreCase));
        }
        public static IEnumerable<IngredientData> GetAdditives()
        {
            return Ingredients.Where(i => i.Type.Equals("Additive", StringComparison.OrdinalIgnoreCase));
        }
        public static bool IsValidIngredient(string name)
        {
            return Ingredients.Any(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
        public static IngredientData GetIngredient(string name)
        {
            return Ingredients.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
    public class IngredientData
    {
        public string Name { get; set; }
        public double? SAPValue { get; set; } // oils only
        public string Type { get; set; } // Oil or Additive
        public double? UsageRate { get; set; } //additives only
    }
}