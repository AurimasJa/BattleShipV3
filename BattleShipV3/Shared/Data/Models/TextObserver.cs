using BattleShipV3.Client.DesignPatterns.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Data.Models
{
    public class TextObserver : IObserver
    {
        public string Text { get; set; } = "0";

        public void Update(ISubject subject)
        {
            this.Text = subject.Count.ToString();
        }
    }
}
