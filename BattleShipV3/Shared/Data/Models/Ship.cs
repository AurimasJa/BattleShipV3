using BattleShipV3.Shared.Data;
using BattleShipV3.Data.Models;

namespace BattleShipV3.Data.Models
{
    public class Ship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public Missile Missile { get; set; }

        public virtual string GetSpecialtyName()
        {
            return "None";
        }
        public virtual int GetSpecialtyBonus()
        {
            return 0;
        }

    }
}
