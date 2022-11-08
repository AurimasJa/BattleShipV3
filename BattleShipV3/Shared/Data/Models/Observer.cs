using BattleShipV3.Client.DesignPatterns.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Data.Models
{
    public class Observer : IObserver
    {
        public string ConnectionString { get; set; }

        public void Update(ISubject subject)
        {
            throw new NotImplementedException();
        }
    }
}
