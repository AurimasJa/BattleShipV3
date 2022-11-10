namespace BattleShipV3.Client.DesignPatterns.Observer
{
    public interface IObserver
    {
        string Text { get; set; }
        void Update(ISubject subject);
    }
}
