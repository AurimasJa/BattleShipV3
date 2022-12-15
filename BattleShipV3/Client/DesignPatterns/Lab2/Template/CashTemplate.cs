using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Models;

namespace BattleShipV3.Client.DesignPatterns.Lab2.Template
{
    public sealed class CashTemplate : TemplateBase
    {
        public CashTemplate(Ship ship) : base(ship)
        {
        }

        protected override void InstantiatePurchase()
        {
            this.purchase = new CashPurchase(ship);
        }

        protected override void SetCost()
        {
            double cost = 0;
            switch (this.ship)
            {
                case Healer:
                    cost += 1.99;
                    break;
                case Submarine:
                    cost += 2.99;
                    break;
                default:
                    cost += 1.49;
                    break;
            }

            cost += 25 * (4 - this.ship.Length);
            cost *= (1 - Discount);
            this.purchase.Cost = cost;
        }

        protected override void SetDiscount()
        {
            this.Discount = 0.5;
        }
    }
}
