using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Visitoras.Visitor
{
    public interface IVisitable
    {

        public double accept(IVisitor visitor);

    }
}
