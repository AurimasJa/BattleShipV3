using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Chain
{
    public class CashHandlerChain : AbstractHandler
    {
        public override object Handle(object request)
        {
            if ((request as string) == "CASH")
            {
                return "For any information you need to contact CASH@BattleShipV3.com";
            }
            else
            {
                return base.Handle(request);
            }
        }

    }
}
