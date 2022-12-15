using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Models;

namespace BattleShipV3.Client.DesignPatterns.Lab2.Template
{
    public sealed class PointsTemplate : TemplateBase
    {
        public PointsTemplate(Ship ship) : base(ship)
        {
        }

        protected override void InstantiatePurchase()
        {
            this.purchase = new PointPurchase(ship);
        }

        protected override void SetCost()
        {
            double cost = 0;
            switch (this.ship)
            {
                case Healer:
                    cost += 150;
                    break;
                case Submarine:
                    cost += 200;
                    break;
                default:
                    cost += 100;
                    break;
            }

            cost += 25 * (4 - this.ship.Length);
            cost *= (1 - Discount);
            this.purchase.Cost = cost;
        }
    }
}
