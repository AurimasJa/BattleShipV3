using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Interfacess;
using BattleShipV3.Shared.Visitoras.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Data.Models
{
    public class CashPurchase : IPurchase
    {
        public double Cost { get; set; }
        public double Discount { get; set; }
        public Ship Ship { get; set; }
        public double CalculateTotalPrice()
        {
            double cost = 0;
            switch (Ship)
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

            cost += 25 * (4 - Ship.Length);
            cost *= (1 - Discount);
            return cost;
        }

        public double accept(IVisitor visitor)
        {
            return visitor.visit(this);
        }

        public CashPurchase(Ship ship)
        {
            this.Ship = ship;
        }
    }
}
