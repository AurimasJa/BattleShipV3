using BattleShipV3.Shared.Data.Models;

namespace BattleShipV3.Client.DesignPatterns.Observer
{
    public class UserEventLogHandler : IObservable<UserEventLog>
    {
        private List<IObserver<UserEventLog>> observers;
        private List<UserEventLog> userEvents;
        public UserEventLogHandler()
        {
            observers = new List<IObserver<UserEventLog>>();
            userEvents = new List<UserEventLog>();
        }
        public IDisposable Subscribe(IObserver<UserEventLog> observer)
        {
            if(!observers.Contains(observer))
            {
                observers.Add(observer);

                foreach (var item in userEvents)
                {
                    observer.OnNext(item);
                }
            }

            return new Unsubscriber<UserEventLog>(observers, observer);
        }
    }

    internal class Unsubscriber<UserEventLog> : IDisposable
    {
        private List<IObserver<UserEventLog>> _observers;
        private IObserver<UserEventLog> _observer;

        internal Unsubscriber(List<IObserver<UserEventLog>> observers, IObserver<UserEventLog> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
