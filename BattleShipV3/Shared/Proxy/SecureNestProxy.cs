using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Proxy
{
    public class SecureNestProxy : IProxy
    {
        private readonly IProxy nest;

        public SecureNestProxy(IProxy nest)
        {
            this.nest = nest;
        }

        public bool Access(string name)
        {
            if (name == "testas")
            {
                Console.WriteLine("You are not eligible to purchase ships");
                return false; 
            }
            else
            {
                this.nest.Access(name);
                return true;
            }
        }
    }
}
