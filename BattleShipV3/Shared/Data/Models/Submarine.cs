namespace BattleShipV3.Data.Models
{
    public class Submarine : Ship
    {
        public int Id { get; set; }
        public int HiddenDuration { get; set; }

        public override int GetSpecialtyBonus()
        {
            return HiddenDuration;
        }
        public override string GetSpecialtyName()
        {
            return "Submerge";
        }
    }
}
