using BattleShipV3.Data;
using static BattleShipV3.Data.Enums;

namespace BattleShipV3.Models
{
    public class GameMatch
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public GameState GameState { get; set; }
        public Listing Listing { get; set; }
        public User User { get; set; }

    }
}
