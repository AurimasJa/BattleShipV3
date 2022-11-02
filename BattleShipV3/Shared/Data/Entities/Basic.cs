namespace BattleShipV3.Data.Models
{
    public class Basic : Ship
    {
        //public int Id { get; set; }

        public override int GetSpecialtyBonus()
        {
            return 0;
        }
        public override string GetSpecialtyName()
        {
            return "None";
        }
    }
}
