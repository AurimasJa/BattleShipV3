using BattleShipV3.Models;
using static BattleShipV3.Data.Enums;

namespace BattleShipV3.Data.Models
{
    public class Turn
    {
        public int Id { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public TurnType TurnType { get; set; }
        public GameMatch GameMatch { get; set; }

    }
}
