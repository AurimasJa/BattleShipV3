using BattleShipV3.Models;

namespace BattleShipV3.Client.DesignPatterns.Strategy
{
    public class FilterStrategyByCreator : IFilterStrategy
    {
        public bool FilterFunction(Listing element, string searchString)
        {
            Console.WriteLine(element.PlayerOne.Name);
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.PlayerOne.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
    }
}
