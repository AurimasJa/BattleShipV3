using BattleShipV3.Models;
using BattleShipV3.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleShipV3.Server.Repositories
{
    public interface IShipsRepository
    {
        Task CreateShipAsync(Ship ship);
        Task DeleteShipAsync(Ship ship);
        Task<IReadOnlyList<Ship>> GetAllShipsAsync();
        Task<Ship?> GetShipAsync(int? shipId);
        Task UpdateShipAsync(Ship ship);
    }

    public class ShipsRepository : IShipsRepository
    {
        private readonly BattleshipDbContext _battleshipDbContext;

        public ShipsRepository(BattleshipDbContext battleshipDbContext)
        {
            _battleshipDbContext = battleshipDbContext;
        }

        public async Task<IReadOnlyList<Ship>> GetAllShipsAsync()
        {

            return await _battleshipDbContext.Ships.
                Include(e => e.Missile).
                ToListAsync();
        }

        public async Task<Ship?> GetShipAsync(int? shipId)
        {
            return await _battleshipDbContext.Ships.
                Include(e => e.Missile).
                FirstOrDefaultAsync(x => x.Id == shipId);
        }

        public async Task CreateShipAsync(Ship ship)
        {
            _battleshipDbContext.Ships.Add(ship);
            await _battleshipDbContext.SaveChangesAsync();
        }

        public async Task UpdateShipAsync(Ship ship)
        {
            _battleshipDbContext.Ships.Update(ship);
            await _battleshipDbContext.SaveChangesAsync();
        }

        public async Task DeleteShipAsync(Ship ship)
        {
            _battleshipDbContext.Ships.Remove(ship);
            await _battleshipDbContext.SaveChangesAsync();
        }
    }
}
