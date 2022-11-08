namespace BattleShipV3.Client.DesignPatterns.Observer
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        Task Notify();

    }
}
