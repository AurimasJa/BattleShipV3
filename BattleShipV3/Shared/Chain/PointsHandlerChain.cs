using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Chain
{
    public class PointsHandlerChain : AbstractHandler
    {
        //double number { get; set; }

        //public AddNumbers(double number)
        //{
        //    this.number = number;
        //}

        public override object Handle(object request)
        {
            if ((request as string) == "POINTS")
            {
                return "For any information you need to contact POINTS@BattleShipV3.com";
            }
            else
            {
                return base.Handle(request);
            }
        }

    }
}
