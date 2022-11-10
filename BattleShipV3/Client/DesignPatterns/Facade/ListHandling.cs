using BattleShipV3.Data.Models;

namespace BattleShipV3.Client.DesignPatterns.Facade
{
    public class ListHandling<T>
    {
        public void MoveFromOneListToOther(List<T> From, List<T> To, T context)
        {
            From.Remove(context);
            To.Add(context);
        }

    }
}
