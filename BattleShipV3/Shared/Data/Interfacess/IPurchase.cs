using BattleShipV3.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Data.Interfacess
{
    public interface IPurchase
    {
        public double Cost { get; set; }
        public double Discount { get; set; }
        Ship Ship { get; set; }
        public double CalculateTotalPrice();
    }
}
