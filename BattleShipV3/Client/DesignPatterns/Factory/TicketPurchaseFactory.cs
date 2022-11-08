using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Interfacess;
using BattleShipV3.Shared.Data.Models;

namespace BattleShipV3.Client.DesignPatterns.Factory
{
    public class TicketPurchaseFactory : Factory
    {
        protected override IPurchase FactoryMethod(Ship ship)
        {
            return new TicketPurchase(ship);
        }
    }
}
