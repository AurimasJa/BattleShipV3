using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Interfacess;
using BattleShipV3.Shared.Data.Models;

namespace BattleShipV3.Client.DesignPatterns.Factory
{
    public class CashPurchaseFactory : Factory
    {
        protected override IPurchase FactoryMethod(Ship ship)
        {
            return new CashPurchase(ship);
        }
    }
}
