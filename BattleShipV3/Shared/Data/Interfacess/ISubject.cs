namespace BattleShipV3.Client.DesignPatterns.Observer
{
    public interface ISubject
    {
        List<IObserver> Observers { get; set; }
        int Count { get; set; }
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();

    }
}
