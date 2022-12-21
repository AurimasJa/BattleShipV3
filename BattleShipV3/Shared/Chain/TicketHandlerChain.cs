using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Chain
{
    public class TicketHandlerChain : AbstractHandler
    {
        public override object Handle(object request)
        {
            if ((request as string) == "TICKET")
            {
                return "For any information you need to contact TICKET@BattleShipV3.com";
            }
            else
            {
                return base.Handle(request);
            }
        }

    }
}
