namespace BattleShipV3.Client.DesignPatterns.Command
{
    public interface ICommand
    {
        public Task Execute(int userId, int shipId);
        public Task Undo(int userId, int shipId);
    }
}
