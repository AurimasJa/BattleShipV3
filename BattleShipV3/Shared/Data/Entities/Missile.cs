using static BattleShipV3.Data.Enums;

namespace BattleShipV3.Data.Models
{
    public class Missile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cooldown { get; set; }
        public MissileType MissileType { get; set; }
    }
}
