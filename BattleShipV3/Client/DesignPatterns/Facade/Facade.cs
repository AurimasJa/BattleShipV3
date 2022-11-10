using BattleShipV3.Client.Services;

namespace BattleShipV3.Client.DesignPatterns.Facade
{
    public class Facade
    {
        private UserShipsService userShipsService { get; set; }
        private ShipService shipService { get; set; }
        private UserService userService { get; set; }

        public Facade(UserShipsService userShipsService, ShipService shipService, UserService userService)
        {
            this.userShipsService = userShipsService;
            this.shipService = shipService;
            this.userService = userService;


        }


    }
}
