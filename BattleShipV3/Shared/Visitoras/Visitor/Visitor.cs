using BattleShipV3.Shared.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Visitoras.Visitor
{
    public interface IVisitor
    {
        public double visit(CashPurchase cashPurchase);

        public double visit(TicketPurchase ticketPurchase);

        public double visit(PointPurchase pointPurchase);
    }
}
