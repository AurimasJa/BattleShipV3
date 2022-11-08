using BattleShipV3.Models;

namespace BattleShipV3.Client.DesignPatterns.Strategy
{
    public interface IFilterStrategy
    {
        public bool FilterFunction(Listing element, string searchString);
    }
}
