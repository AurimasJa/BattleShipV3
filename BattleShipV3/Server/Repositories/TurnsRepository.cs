using BattleShipV3.Data.Models;
using BattleShipV3.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleShipV3.Server.Repositories
{
    public interface ITurnsRepository
    {
        Task CreateTurnAsync(Turn turn);
        Task DeleteTurnAsync(Turn turn);
        Task<Turn?> GetTurnAsync(int? turnId);
        Task<IReadOnlyList<Turn>> GetTurnsAsync();
    }

    public class TurnsRepository : ITurnsRepository
    {
        private readonly BattleshipDbContext _battleshipDbContext;

        public TurnsRepository(BattleshipDbContext battleshipDbContext)
        {
            _battleshipDbContext = battleshipDbContext;
        }

        public async Task<IReadOnlyList<Turn>> GetTurnsAsync()
        {
            return await _battleshipDbContext.Turns.ToListAsync();
        }

        public async Task<Turn?> GetTurnAsync(int? turnId)
        {

            return await _battleshipDbContext.Turns.FirstOrDefaultAsync(x => x.Id == turnId);
        }

        public async Task CreateTurnAsync(Turn turn)
        {
            _battleshipDbContext.Turns.Add(turn);
            await _battleshipDbContext.SaveChangesAsync();
        }

        //public async Task UpdateTurnAsync(Turn turn)
        //{
        //    _battleshipDbContext.Turns.Update(turn);
        //    await _battleshipDbContext.SaveChangesAsync();
        //}

        public async Task DeleteTurnAsync(Turn turn)
        {
            _battleshipDbContext.Turns.Remove(turn);
            await _battleshipDbContext.SaveChangesAsync();
        }
    }
}
