using BattleShipV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Proxy
{
    public interface Proxy
    {
        bool Access(string name);
    }
}
