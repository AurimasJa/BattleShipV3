using BattleShipV3.Models;
using BattleShipV3.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleShipV3.Server.Repositories
{
    public interface IMissilesRepository
    {
        Task CreateMissileAsync(Missile missile);
        Task DeleteMissileAsync(Missile missile);
        Task<IReadOnlyList<Missile>> GetAllMissilesAsync();
        Task<Missile?> GetMissileAsync(int? missileId);
        Task UpdateMissileAsync(Missile missile);
    }

    public class MissilesRepository : IMissilesRepository
    {
        private readonly BattleshipDbContext _battleshipDbContext;

        public MissilesRepository(BattleshipDbContext battleshipDbContext)
        {
            _battleshipDbContext = battleshipDbContext;
        }

        public async Task<IReadOnlyList<Missile>> GetAllMissilesAsync()
        {

            return await _battleshipDbContext.Missiles.ToListAsync();
        }

        public async Task<Missile?> GetMissileAsync(int? missileId)
        {
            return await _battleshipDbContext.Missiles.FirstOrDefaultAsync(x => x.Id == missileId);
        }

        public async Task CreateMissileAsync(Missile missile)
        {
            _battleshipDbContext.Missiles.Add(missile);
            await _battleshipDbContext.SaveChangesAsync();
        }

        public async Task UpdateMissileAsync(Missile missile)
        {
            _battleshipDbContext.Missiles.Update(missile);
            await _battleshipDbContext.SaveChangesAsync();
        }

        public async Task DeleteMissileAsync(Missile missile)
        {
            _battleshipDbContext.Missiles.Remove(missile);
            await _battleshipDbContext.SaveChangesAsync();
        }
    }
}
