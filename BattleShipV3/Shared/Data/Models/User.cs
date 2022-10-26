using BattleShipV3.Data.Models;

namespace BattleShipV3.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public double Elo { get; set; }
        public int Points { get; set; }

    }
}
