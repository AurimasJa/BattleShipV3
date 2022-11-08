using BattleShipV3.Models;

namespace BattleShipV3.Client.DesignPatterns.Strategy
{
    public class FilterStrategyByName : IFilterStrategy
    {
        public bool FilterFunction(Listing element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
    }
}
