using BattleShipV3.Shared.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Visitoras.Visitor
{
    public class TaxVisitor : Visitor
    {
        public double visit(CashPurchase cashPurchase)
        {
            return (cashPurchase.Cost *= 100);
        }

        public double visit(TicketPurchase ticketPurchase)
        {
            return (ticketPurchase.Cost *= 1000);
        }

        public double visit(PointPurchase pointPurchase)
        {
            return (pointPurchase.Cost *= 10);
        }
    }
}
