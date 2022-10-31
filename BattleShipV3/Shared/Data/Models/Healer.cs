namespace BattleShipV3.Data.Models
{
    public class Healer : Ship
    {
        public int Id { get; set; }

        public int HealBonus { get; set; }

        public override int GetSpecialtyBonus()
        {
            return HealBonus;
        }
        public override string GetSpecialtyName()
        {
            return "Healing";
        }
    }
}
