using BattleShipV3.Client.DesignPatterns.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Data.Models
{
    public class ButtonSubject : ISubject
    {
        public int Count { get; set; } = 0;
        public List<IObserver> Observers { get; set; } = new List<IObserver> { };
        public void Attach(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in Observers)
            {
                observer.Update(this);
            }
        }
    }
}
