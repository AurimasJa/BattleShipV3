using BattleShipV3.Data.Models;
using BattleShipV3.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleShipV3
{
    public class BattleshipDbContext : DbContext
    {
        public DbSet<GameMatch> GameMatches { get; set; }
        public DbSet<Healer> Healers { get; set; }
        public DbSet<LeaderboardHistory> LeaderboardHistories { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Missile> Missiles { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<ShipPlacement> ShipPlacements { get; set; }
        public DbSet<Submarine> Submarines { get; set; }
        public DbSet<Turn> Turns { get; set; }
        public DbSet<UserShip> UserShips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:battleshipserver.database.windows.net,1433;Initial Catalog=Battleship;Persist Security Info=False;User ID=admin1;Password=Battleship1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

    }
}
