using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Chain
{
    public class MultNumbers : AbstractHandler
    {
        double number;

        public MultNumbers(double number)
        {
            this.number = number;
        }
        public override object Handle(object request)
        {
            if (request.ToString() == "10")
            {
                return 10 * number;
            }
            else
            {
                return base.Handle(request);
            }
        }

    }
}
