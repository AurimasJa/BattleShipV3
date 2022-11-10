using BattleShipV3.Data;
using static BattleShipV3.Data.Enums;

namespace BattleShipV3.Client.DesignPatterns.Bridge
{
    public class ColorChangerPurple : IColorChanger
    {
        public ShipColor ChangeShipColor()
        {
            return ShipColor.PURPLE;
        }
    }
}
