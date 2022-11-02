using BattleShipV3.Data.Models;

namespace BattleShipV3.Client.DesignPatterns.Builder
{
    public class HealerShipBuilder : ShipBuilder
    {
        public HealerShipBuilder()
        {
            this.ship = new Ship();
        }

        public override ShipBuilder BuildShipColor()
        {
            ship.Color = Data.Enums.ShipColor.GREEN;
            return this;
        }
    }

}