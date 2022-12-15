using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Chain
{
    public class AddNumbers : AbstractHandler
    {
        double number { get; set; }

        public AddNumbers(double number)
        {
            this.number = number;
        }

        public override object Handle(object request)
        {
            if ((request as string) == "20")
            {
                return number + 10;
            }
            else
            {
                return base.Handle(request);
            }
        }

    }
}
