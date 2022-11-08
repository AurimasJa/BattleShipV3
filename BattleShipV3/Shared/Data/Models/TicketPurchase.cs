﻿using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Interfacess;
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
        public override double CalculateTotalPrice()
        {
            return 1;
        }
        public TicketPurchase(Ship ship)
        {
            this.Ship = ship;
        }
    }
}
