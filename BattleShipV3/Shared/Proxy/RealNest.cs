using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Proxy
{
    public class RealNest : Proxy
    {
        public bool Access(string name)
        {
            Console.WriteLine($"{name} has access to the nest");
            return true;
        }
    }
}
