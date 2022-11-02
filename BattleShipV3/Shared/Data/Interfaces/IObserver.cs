using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Data.Interfaces
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }
}
