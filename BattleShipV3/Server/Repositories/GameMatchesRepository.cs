using BattleShipV3.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleShipV3.Server.Repositories
{
    public interface IGameMatchesRepository
    {
        Task CreateGameMatchAsync(GameMatch gameMatch);
        Task DeleteGameMatchAsync(GameMatch gameMatch);
        Task<IReadOnlyList<GameMatch>> GetAllGameMatchesAsync();
        Task<GameMatch?> GetGameMatchAsync(int? gameMatchId);
        Task UpdateGameMatchAsync(GameMatch gameMatch);
    }

    public class GameMatchesRepository : IGameMatchesRepository
    {

        private readonly BattleshipDbContext _battleshipDbContext;

        public GameMatchesRepository(BattleshipDbContext battleshipDbContext)
        {
            _battleshipDbContext = battleshipDbContext;
        }

        public async Task<IReadOnlyList<GameMatch>> GetAllGameMatchesAsync()
        {

            return await _battleshipDbContext.GameMatches
                .Include(e => e.User)
                .Include(x => x.Listing)
                .ToListAsync();
        }

        public async Task<GameMatch?> GetGameMatchAsync(int? gameMatchId)
        {
            return await _battleshipDbContext.GameMatches
                .Include(e => e.User)
                .Include(x => x.Listing)
                .FirstOrDefaultAsync(x => x.Id == gameMatchId);
        }

        public async Task CreateGameMatchAsync(GameMatch gameMatch)
        {
            _battleshipDbContext.GameMatches.Add(gameMatch);
            await _battleshipDbContext.SaveChangesAsync();
        }

        public async Task UpdateGameMatchAsync(GameMatch gameMatch)
        {
            _battleshipDbContext.GameMatches.Update(gameMatch);
            await _battleshipDbContext.SaveChangesAsync();
        }

        public async Task DeleteGameMatchAsync(GameMatch gameMatch)
        {
            _battleshipDbContext.GameMatches.Remove(gameMatch);
            await _battleshipDbContext.SaveChangesAsync();
        }
    }
}
