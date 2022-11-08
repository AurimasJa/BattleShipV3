using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Interfacess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Data.Models
{
    public class PointPurchase : IPurchase
    {
        public double Cost { get; set; }
        public double Discount { get; set; } = 0;
        public Ship Ship { get; set; }
        public override double CalculateTotalPrice()
        {
            double cost = 0;
            switch (Ship)
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

            cost += 25 * (4 - Ship.Length);
            cost *= (1 - Discount);
            return cost;
        }
        public PointPurchase(Ship ship)
        {
            this.Ship = ship;
        }
    }
}
