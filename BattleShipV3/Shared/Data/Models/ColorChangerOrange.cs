using BattleShipV3.Data;
using static BattleShipV3.Data.Enums;

namespace BattleShipV3.Client.DesignPatterns.Bridge
{
    public class ColorChangerOrange : IColorChanger
    {
        public ShipColor ChangeShipColor()
        {
            return ShipColor.ORANGE;
        }
    }
}
