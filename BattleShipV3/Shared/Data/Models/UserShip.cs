using BattleShipV3.Models;

namespace BattleShipV3.Data.Models
{
    public class UserShip
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Ship Ship { get; set; }
    }
}
