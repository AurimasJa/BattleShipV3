using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Visitoras.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Data.Interfacess
{
    public interface IPurchase : Visitable
    {
        public double Cost { get; set; }
        public double Discount { get; set; }
        Ship Ship { get; set; }
        public double CalculateTotalPrice();
    }
}
