using DesertRainSoap.Models;

namespace DesertRainSoap.Interfaces 
{
    public interface IOilInputHandler
    {
        void AddOils(RecipeBase recipe, double totalWeight, WeightUnit unit);
    }

    public interface IRecipeFormatter
    {
        void DisplayRecipeSummary(RecipeBase recipe, double superFat, double totalOilWeight, double tspInput);
    }
}