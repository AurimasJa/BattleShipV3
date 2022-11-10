using BattleShipV3.Client.Services;
using BattleShipV3.Data.Models;
using BattleShipV3.Shared;
using BattleShipV3.Shared.Data.Commands.User.Update;
using BattleShipV3.Shared.Data.Commands.UserShips.Create;
using BattleShipV3.Shared.Data.Interfacess;
using static BattleShipV3.Data.Enums;

namespace BattleShipV3.Client.DesignPatterns.Facade
{
    public class Facade
    {
        private UserShipsService userShipsService { get; set; }
        private ShipService shipService { get; set; }
        private UserService userService { get; set; }
        private ListHandling<Ship> shipListHandling { get; set; }

        public Facade(UserShipsService userShipsService, ShipService shipService, UserService userService)
        {
            this.userShipsService = userShipsService;
            this.shipService = shipService;
            this.userService = userService;
            this.shipListHandling = new ListHandling<Ship>();

        }

        public async Task<List<Ship>> GetShipsForRepertoire()
        {
            return null;
        }

        //User moves ship from List 'from' to 'to' and makes a call to a service
        public async Task UserRemoveShip(List<Ship> from, List<Ship> to, Ship context, int userId)
        {
            shipListHandling.MoveFromOneListToOther(from, to, context);
            await userShipsService.RemoveUserSelectedShip(userId, context.Id);
        }

        public async Task HandleShipPurchase(IPurchase purchase, PurchaseType purchaseType, Ship selectedShip, List<Ship> ownedShips)
        {
            if (((purchase.Cost <= Global.CurrentUser.Points) || (purchaseType == PurchaseType.CASH)) && (purchaseType != PurchaseType.TICKET))
            {
                CreateUserShipsCommand userShip = new CreateUserShipsCommand(Global.CurrentUser.Id, selectedShip.Id);
                await userShipsService.InsertUserShipsAsync(userShip);
                ownedShips.Add(selectedShip);
                if (purchaseType == PurchaseType.POINTS)
                {
                    Global.CurrentUser.Points -= (int)purchase.Cost;
                    UpdateUserCommand cmd = new UpdateUserCommand(null, null, null, null, Global.CurrentUser.Points);
                    await userService.UpdateUserAsync(Global.CurrentUser.Id, cmd);
                }
                else if (purchaseType == PurchaseType.CASH)
                {
                    //TODO CASH
                }
                else
                {
                    //TODO TICKETS
                }
            }
        }

    }
}
