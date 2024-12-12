using System;
using System.Collections.Generic;
using DesertRainSoap.Data;

namespace DesertRainSoap.Handlers
{
    public abstract class BaseOilInputHandler
    {
        //method to display available oils
        protected void DisplayAvailableOils()
        {
            Console.WriteLine("Available Oils:");
            foreach (var oil in IngredientRepository.GetOils())
            {
                Console.WriteLine($"{oil.Name}");
            }
        }
        //method to validate oil name
        protected bool ValidateOilName(string oilName)
        {
            return SAPValues.Values.ContainsKey(oilName);
        }
    }
}