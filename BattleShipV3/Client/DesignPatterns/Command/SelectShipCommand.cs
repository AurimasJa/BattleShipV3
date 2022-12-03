using BattleShipV3.Client.Services;
using BattleShipV3.Shared.Data.Commands.UserShips.Create;
using static BattleShipV3.Client.Pages.GameMatches.GameMap;

namespace BattleShipV3.Client.DesignPatterns.Command
{
    public class SelectShipCommand : ICommand
    {
        ShipService _shipService;
        UserShipsService _userShipService;
        public SelectShipCommand(ShipService shipService, UserShipsService userShipService)
        {
            this._shipService = shipService;
            this._userShipService = userShipService;
        }
        public async Task Execute(int userId, int shipId)
        {
            CreateUserSelectedShipCommand cmd = new CreateUserSelectedShipCommand(userId, shipId);

            await _shipService.InsertUserSelectedShipAsync(cmd);
        }

        public async Task Undo(int userId, int shipId)
        {
            await _userShipService.RemoveUserSelectedShip(userId, shipId);
        }
    }
}
