using BattleShipV3.Models;

namespace BattleShipV3.Data.Models
{
    public class LeaderboardHistory
    {
        public int Id { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public User User { get; set; }
    }
}
