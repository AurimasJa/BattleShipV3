using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Visitoras.Visitor
{
    public interface Visitable
    {

        public double accept(Visitor visitor);

    }
}
