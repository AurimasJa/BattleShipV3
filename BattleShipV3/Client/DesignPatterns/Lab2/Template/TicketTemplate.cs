using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Models;

namespace BattleShipV3.Client.DesignPatterns.Lab2.Template
{
    public sealed class TicketTemplate : TemplateBase
    {
        public TicketTemplate(Ship ship) : base(ship)
        {
        }

        protected override void InstantiatePurchase()
        {
            this.purchase = new TicketPurchase(ship);
        }

        protected override void SetCost()
        {
            this.purchase.Cost = 1;
        }
    }
}
