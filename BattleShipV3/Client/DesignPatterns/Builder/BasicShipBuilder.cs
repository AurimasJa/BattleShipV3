using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Models;

namespace BattleShipV3.Client.DesignPatterns.Builder
{
    public class BasicShipBuilder : ShipBuilder
    {
        public BasicShipBuilder()
        {
            this.ship = new Ship();
        }

        public override ShipBuilder BuildShipColor()
        {
            ship.Color = Data.Enums.ShipColor.WHITE;
            return this;
        }
    }
}
