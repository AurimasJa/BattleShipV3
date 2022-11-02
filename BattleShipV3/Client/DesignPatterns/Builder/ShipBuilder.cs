using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Models;

namespace BattleShipV3.Client.DesignPatterns.Builder
{
    abstract public class ShipBuilder
    {
        protected Ship ship;
        public abstract ShipBuilder BuildShipColor();

        public ShipBuilder startNew(Ship newShip)
        {
            this.ship = newShip;
            return this;
        }

        public Ship GetBuildable()
        {
            return this.ship;
        }

    }
}
