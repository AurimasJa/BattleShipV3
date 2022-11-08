using BattleShipV3.Models;

namespace BattleShipV3.Client.DesignPatterns.Strategy
{
    public class FilterStrategyByLessMaxElo : IFilterStrategy
    {
        public bool FilterFunction(Listing element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;

            int search;
            if (!int.TryParse(searchString, out search))
                return false;

            if (element.EloTo < search)
                return true;

            return false;
        }
    }
}
