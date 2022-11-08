using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Interfacess;

namespace BattleShipV3.Client.DesignPatterns.Factory
{
    public abstract class Factory
    {
        protected abstract IPurchase FactoryMethod(Ship ship);

        public IPurchase GetCreatedPurchase(Ship ship)
        {
            var purchase = FactoryMethod(ship);
            purchase.Cost = purchase.CalculateTotalPrice();
            return purchase;
        }
    }
}
