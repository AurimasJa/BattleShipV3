using BattleShipV3.Data.Models;

namespace BattleShipV3.Client.DesignPatterns.Builder
{
    public class SubmarineShipBuilder : ShipBuilder
    {
        public SubmarineShipBuilder()
        {
            this.ship = new Ship();
        }

        public override ShipBuilder BuildShipColor()
        {
            ship.Color = Data.Enums.ShipColor.BLUE;
            return this;
        }
    }
}
