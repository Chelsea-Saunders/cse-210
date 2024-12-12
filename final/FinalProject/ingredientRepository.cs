using System;
using System.Collections.Generic;
using System.Linq;

namespace DesertRainSoap.Data
{
    public static class IngredientRepository
    {
        static IngredientRepository()
        {
            //add oils dynamically
            foreach (var oil in SAPValues.Values)
            {
                Ingredients.Add(new IngredientInfo(oil.Key, "Oil", oil.Value));
            }

            //add additives
            foreach (var additive in Additive.Values)
            {
                Ingredients.Add(new IngredientInfo(additive.Key, "Additive", additive.Value));
            }
        }
        private static readonly List<IngredientInfo> Ingredients = new List<IngredientInfo>();

        // Methods to get oils, additives, and validation
        public static IEnumerable<IngredientInfo> GetOils()
        {
            return Ingredients.Where(i => i.Type == "Oil");
        }

        public static IEnumerable<IngredientInfo> GetAdditives()
        {
            return Ingredients.Where(i => i.Type == "Additive");
        }

        public static bool IsValidIngredient(string name)
        {
            return Ingredients.Any(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public static IngredientInfo GetIngredient(string name)
        {
            return Ingredients.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
