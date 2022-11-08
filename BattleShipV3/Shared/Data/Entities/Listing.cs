
using BattleShipV3.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BattleShipV3.Client.DesignPatterns.Observer;

namespace BattleShipV3.Models
{
    public class Listing : ISubject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double? EloFrom { get; set; }
        public double? EloTo { get; set; }
        public DateTime CreationDate { get; set; }
        public User PlayerOne { get; set; }
        public User? PlayerTwo { get; set; }
        [NotMapped]
        public string PlayerOneConnId { get; set; } = "";
        [NotMapped]
        public string PlayerTwoConnId { get; set; } = "";

        [NotMapped]
        private List<IObserver> Observers { get; set; } = new List<IObserver>();
        [NotMapped]
        public Func<Task> AlertObserversFunc { get; set; }

        public void Attach(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public async Task Notify()
        {
            if (AlertObserversFunc == null)
                return;
            await AlertObserversFunc.Invoke();
        }
    }
}
