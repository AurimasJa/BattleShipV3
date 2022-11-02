using BattleShipV3.Models;
using BattleShipV3.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleShipV3.Server.Repositories
{
    public interface IShipsRepository
    {
        Task CreateShipAsync(Ship ship);
        Task CreateUserSelectedShipAsync(UserSelectedShip uss);
        Task DeleteShipAsync(Ship ship);
        Task<IReadOnlyList<Ship>> GetAllOneUserShipsAsync(int userId, bool? selected);
        Task<IReadOnlyList<Ship>> GetAllShipsAsync();
        Task<Ship?> GetShipAsync(int? shipId);
        Task UpdateShipAsync(Ship ship);
        Task RemoveUserSelectedShipAsync(int userId, int shipId);
    }

    // TURI BUTI SHIP->PAIMA VISUS SHIPS sutikrines su UserShips
    //public interface IShipsRepository
    //{
    //    Task CreateShipAsync(Ship ship);
    //    Task DeleteShipAsync(Ship ship);
    //    Task<IReadOnlyList<Ship>> GetAllShipsAsync();
    //    Task<Ship?> GetShipAsync(int? shipId);
    //    Task UpdateShipAsync(Ship ship);
    //}

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

        public async Task<IReadOnlyList<Ship>> GetAllOneUserShipsAsync(int userId, bool? selected)
        {
            return selected == true ? await GetSelectedShips(userId) : await GetOwnedShips(userId);
        }

        public async Task RemoveUserSelectedShipAsync(int userId, int shipId)
        {
            var uss = await _battleshipDbContext.UserSelectedShips
                 .Include(e => e.User)
                 .Include(e => e.Ship)
                .FirstOrDefaultAsync(e => e.User.Id == userId && e.Ship.Id == shipId);
            _battleshipDbContext.UserSelectedShips.Remove(uss);
            await _battleshipDbContext.SaveChangesAsync();
        }

        private async Task<IReadOnlyList<Ship>> GetOwnedShips(int userId)
        {
            var userSelectedShips = await _battleshipDbContext.UserSelectedShips
                                    .Include(e => e.User)
                                    .Include(e => e.Ship)
                                    .Where(e => e.User.Id == userId)
                                    .AsNoTracking()
                                    .ToListAsync();

            var selectedShipIds = userSelectedShips.Select(e => e.Ship.Id).ToHashSet();

            var userShips = await _battleshipDbContext.UserShips
                .Include(e => e.User)
                .Include(e => e.Ship)
                    .ThenInclude(e => e.Missile)
                .Where(o => o.User.Id == userId).ToListAsync();
            var shipids = userShips.Select(o => o.Ship.Id).ToHashSet();

            return await _battleshipDbContext.Ships.Where(o => shipids.Contains(o.Id) && !selectedShipIds.Contains(o.Id)).ToListAsync();
        }

        public async Task CreateUserSelectedShipAsync(UserSelectedShip uss)
        {
            _battleshipDbContext.UserSelectedShips.Add(uss);
            await _battleshipDbContext.SaveChangesAsync();
        }

        private async Task<IReadOnlyList<Ship>> GetSelectedShips(int userId)
        {
            var local = await _battleshipDbContext.UserSelectedShips
                .Include(e => e.User)
                .Include(e => e.Ship)
                    .ThenInclude(e => e.Missile)
                .Where(o => o.User.Id == userId).ToListAsync();
            var shipids = local.Select(o => o.Ship.Id).ToHashSet();

            return await _battleshipDbContext.Ships.Where(o => shipids.Contains(o.Id)).ToListAsync();
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
