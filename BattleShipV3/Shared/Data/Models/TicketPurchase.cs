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
    public class TicketPurchase : IPurchase
    {
        public double Cost { get; set; }
        public double Discount { get; set; }
        public Ship Ship { get; set; }
        public double CalculateTotalPrice()
        {
            return 1;
        }

        public double accept(IVisitor visitor)
        {
            return visitor.visit(this);
        }

        public TicketPurchase(Ship ship)
        {
            this.Ship = ship;
        }
    }
}
