using BattleShipV3.Models;

namespace BattleShipV3.Server.Mediator
{
    public interface IMediator
    {
        Task<User> notify(object sender, object data);
    }
}
